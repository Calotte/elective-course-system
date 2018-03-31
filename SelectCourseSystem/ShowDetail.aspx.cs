using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Script.Serialization;

namespace SelectCourseSystem
{
    public partial class ShowDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string CourseName = Convert.ToString(Session["CourseName"]);
            Label1.Text = CourseName;
            GridView1.DataBind();
        }
        public string CourseName { get { return (string)Session["CourseName"]; } }
        protected void LinqDataSource1_Selecting1(object sender, LinqDataSourceSelectEventArgs e)
        {
            string courseid = (string)Session["CourseID"];
            ustcsseDataContext db = new ustcsseDataContext();
            e.Result = from p in db.SelectInfo
                       where p.CourseID == courseid
                       select p;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ustcsseConnectionString"].ConnectionString);
            conn.Open();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                string updateSql = "UPDATE SelectInfo SET IsSelected=0";
                SqlCommand comm_update = new SqlCommand(updateSql, conn);
                comm_update.CommandText = updateSql;
                comm_update.Connection = conn;
                comm_update.Transaction = tran;
                comm_update.ExecuteNonQuery();
                tran.Commit();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('重置成功')", true);
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('重置失败')", true);
                tran.Rollback();
            }finally
            {
                conn.Close();
            }
        }
        Tuple<string,string> getNameYear(string sno)
        {           
            string name = "张三默认",year="1997-9-1";           
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["remoteConnectionString"].ConnectionString);
            conn.Open();
            string sqlquery = "SELECT* FROM rStudent WHERE RStuNo=@sno";
            SqlCommand sc = new SqlCommand(sqlquery, conn);
            sc.Parameters.Add(new SqlParameter("sno", sno));
            SqlDataReader reader = sc.ExecuteReader();
            if (reader.Read())
            {
                name= Convert.ToString(reader["RName"]);
                year = Convert.ToString(reader["SchoolYear"]);
            }
            Tuple<string, string> t = new Tuple<string, string>(name, year);
            return t;
        }
        
        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["remoteConnectionString"].ConnectionString);
            conn.Open();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                for (int i = 0; i < GridView1.Rows.Count; ++i)
                {
                    int isSelect = Convert.ToInt32(GridView1.Rows[i].Cells[2].Text);
                    if (isSelect != 1) break;                   
                    string sqlStr = "";
                    string StudentID = GridView1.Rows[i].Cells[0].Text.Trim().ToString();
                    Tuple<string, string> t = getNameYear(StudentID);
                    string StudentName = t.Item1, SchoolYear = t.Item2;
                    string courseID= GridView1.Rows[i].Cells[1].Text.Trim().ToString();
                    sqlStr = "INSERT  INTO ElectiveStudent(StudentID,StudentName,CourseID,Year) VALUES ('" + StudentID + "','" + StudentName + "','" + courseID + "','" + SchoolYear +"')";
                    SqlCommand comm = new SqlCommand(sqlStr, conn);
                    comm.CommandText = sqlStr;
                    comm.Connection = conn;
                    comm.Transaction = tran;
                    comm.ExecuteNonQuery();                  
                }
                tran.Commit();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('导出信息成功，请勿重复导入！')", true);
            }
            catch (Exception ex)
            {
                var message = new JavaScriptSerializer().Serialize("导出失败，原因："+ex.Message.ToString());
                var script = string.Format("alert({0});", message);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", script, true);
                tran.Rollback();
            }
            finally
            {
                conn.Close();
            }
        }
    }
}