using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Script.Serialization;

namespace SelectCourseSystem
{
    public partial class ElectiveCourse : System.Web.UI.Page
    {
        public string stuID;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["Student"] != null)
            {
                stuID = (string)Session["Student"];
            }
            else
            {
                Response.Write("<script>parent.window.location.href='Login.aspx'</script>");
            }
        }
        Tuple<int, int> getCredits()
        {
            int credit = 0;
            int maxCredit = 0;        
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ustcsseConnectionString"].ConnectionString);
            conn.Open();
            string sqlquery = "SELECT* FROM Student WHERE StudentID=@stuID";
            SqlCommand sc = new SqlCommand(sqlquery, conn);
            sc.Parameters.Add(new SqlParameter("stuID", stuID));
            SqlDataReader reader = sc.ExecuteReader();
            if (reader.Read())
            {                
                credit = Convert.ToInt32(reader["currentCredit"]);
                maxCredit = Convert.ToInt32(reader["maxCredit"]);
            }
            Tuple<int,int> t = new Tuple<int, int>(credit, maxCredit);
            return t;
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            string courseid = GridView1.SelectedRow.Cells[0].Text;
            string courseName = GridView1.SelectedRow.Cells[1].Text;
            int currentNumber = Convert.ToInt32(GridView1.SelectedRow.Cells[8].Text);
            int credit= Convert.ToInt32(GridView1.SelectedRow.Cells[2].Text);
            Tuple<int, int> credits = getCredits();
            int curCredit = credit + credits.Item1;
            currentNumber++;
            string majorType = GridView1.SelectedRow.Cells[10].Text;
            string insertSql = "INSERT INTO SelectInfo (CourseID,StudentID,IsSelected,MajorType,CourseName,Credit) VALUES (@courseid,@stuID,0,@majorType,@courseName,@credit)";
            string updateSql = "UPDATE CourseInfo SET CurrentNumber=@currentNumber WHERE CourseID=@courseid";
            string updateStu = "UPDATE Student SET currentCredit=@curCredit WHERE StudentID=@stuID";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ustcsseConnectionString"].ConnectionString);
            conn.Open();
            SqlTransaction tran = conn.BeginTransaction();
             try{
                if (curCredit > credits.Item2)
                {
                    throw new Exception("不能超过限选学分！");
                }              
                SqlCommand cmd = new SqlCommand(insertSql, conn);
                cmd.Connection =conn;
                cmd.Transaction = tran;
               SqlCommand cmd2 = new SqlCommand(updateSql, conn);
                cmd2.Connection = conn;
                cmd2.Transaction = tran;
                SqlCommand cmd3 = new SqlCommand(updateStu, conn);
                cmd3.Connection = conn;
                cmd3.Transaction = tran;
                cmd.Parameters.Add(new SqlParameter("courseid", courseid));
                 cmd.Parameters.Add(new SqlParameter("stuID", stuID));
                 cmd.Parameters.Add(new SqlParameter("majorType", majorType));
                cmd.Parameters.Add(new SqlParameter("courseName", courseName));
                cmd.Parameters.Add(new SqlParameter("credit", credit));
                cmd2.Parameters.Add(new SqlParameter("courseid", courseid));
                cmd2.Parameters.Add(new SqlParameter("currentNumber", currentNumber));
                cmd3.Parameters.Add(new SqlParameter("curCredit", curCredit));
                cmd3.Parameters.Add(new SqlParameter("stuID", stuID));
                cmd.ExecuteNonQuery();
                 cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                tran.Commit();
                //Response.Write("<script>alert('选课成功');</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SuccessMessage", "alter('选课成功')", true);
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                var message = new JavaScriptSerializer().Serialize("选课失败，原因：" + ex.Message.ToString());
                var script = string.Format("alert({0});", message);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", script, true);
                tran.Rollback();
            }
            finally
                    {
                        conn.Close();
                    }          
        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
    }
}