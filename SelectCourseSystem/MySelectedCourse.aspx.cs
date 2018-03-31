using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace SelectCourseSystem
{
    public partial class MySelectedCourse : System.Web.UI.Page
    {
        private string stuID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Student"] != null)
            {
                stuID = (string)Session["Student"];
                Label1.Text = "你好："+stuID;
            }
            else
            {
                Response.Write("<script>parent.window.location.href='Login.aspx'</script>");
            }
        }
        int getCredit()
        {
            int credit = 0;           
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ustcsseConnectionString"].ConnectionString);
            conn.Open();
            string sqlquery = "SELECT* FROM Student WHERE StudentID=@stuID";
            SqlCommand sc = new SqlCommand(sqlquery, conn);
            sc.Parameters.Add(new SqlParameter("stuID", stuID));
            SqlDataReader reader = sc.ExecuteReader();
            if (reader.Read())
            {
                credit = Convert.ToInt32(reader["currentCredit"]);
            }
            return credit;
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int curCredit = getCredit()-Convert.ToInt32(GridView1.SelectedRow.Cells[2].Text);
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ustcsseConnectionString"].ConnectionString);
            conn.Open();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                string courseid = GridView1.SelectedRow.Cells[1].Text;
                string sqlStr = "Delete SelectInfo where CourseID= '" + courseid + "'";
                string updateSql = "UPDATE CourseInfo SET CurrentNumber=CurrentNumber-1 WHERE CourseID= '" + courseid + "'";
                string updateStu = "UPDATE Student SET currentCredit=@curCredit WHERE StudentID=@stuID";
                SqlCommand comm = new SqlCommand(sqlStr, conn);
                SqlCommand comm_update = new SqlCommand(updateSql, conn);
                SqlCommand comm_Stu = new SqlCommand(updateSql, conn);
                comm.CommandText = sqlStr;
                comm.Connection = conn;
                comm.Transaction = tran;
                comm_update.CommandText = updateSql;
                comm_update.Connection = conn;
                comm_update.Transaction = tran;
                comm_Stu.CommandText = updateStu;
                comm_Stu.Connection = conn;
                comm_Stu.Transaction = tran;
                comm_Stu.Parameters.Add(new SqlParameter("curCredit", curCredit));
                comm_Stu.Parameters.Add(new SqlParameter("stuID", stuID));
                comm.ExecuteNonQuery();
                comm_update.ExecuteNonQuery();
                comm_Stu.ExecuteNonQuery();
                tran.Commit();
                //Response.Write("<script>alert('退课成功！');</script>");   
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('退课成功')", true);
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                //Response.Write("<script>alert('现在无法退课');</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('现在无法退课')", true);
                tran.Rollback();
            }
            finally
            {
                conn.Close();
            }
        }

        protected void LinqDataSource1_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            ustcsseDataContext db = new ustcsseDataContext();
            e.Result = from p in db.SelectInfo
                       where p.StudentID == stuID
                       select p;
        } 
    }
}