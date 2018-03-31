using System;
using System.Collections;
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
    public partial class Lottery : System.Web.UI.Page
    {
        private int weight=25;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public static void Swap(IList<LotteryStudent> list, int indexA, int indexB)
        {
            LotteryStudent tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
        }

        void select(List<LotteryStudent> ls, int total, int limit)
        {  //defalut: limit<total
            Random rdm = new Random(DateTime.Now.Ticks.GetHashCode());
            for (int i = 0, j = 0; j < limit; i++)
            {
                if (i == total) i = j;
                if (ls[i].IsSelected == 0)
                {
                    double value = rdm.Next(1, total * 2);
                    if (!string.IsNullOrWhiteSpace(TextBox1.Text))
                        weight = Convert.ToInt32(TextBox1.Text);
                    if (ls[i].Flag == 1)   //如果是本专业则增大其被选中的概率
                        value /=(1+weight/100);
                    if (value <= limit)
                    {    //如果被选中，将其标志设为1
                        ls[i].IsSelected=1;
                        Swap(ls, i, j);
                        j++;
                    }
                }
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<LotteryStudent> all = new List<LotteryStudent>();
            Session["CourseName"] = GridView1.SelectedRow.Cells[0].Text;
            string courseid = GridView1.SelectedRow.Cells[1].Text;
            string major="";
            int total=0, limit=0;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ustcsseConnectionString"].ConnectionString);
            string sqlquery = "SELECT* FROM SelectInfo WHERE CourseId=@courseid";
            string sqlquery2 = "SELECT* FROM CourseInfo WHERE CourseId=@courseid";
            using (conn)
            {
                conn.Open();
                SqlCommand sc = new SqlCommand(sqlquery, conn);
                SqlCommand sc2 = new SqlCommand(sqlquery2, conn);
               sc.Parameters.Add(new SqlParameter("courseid", courseid));
                sc2.Parameters.Add(new SqlParameter("courseid", courseid));
                SqlDataReader reader2 = sc2.ExecuteReader();
                if (reader2.Read())
                {
                    major = Convert.ToString(reader2["MajorType"]);
                    total = Convert.ToInt32(reader2["CurrentNumber"]);
                    limit= Convert.ToInt32(reader2["MaxNumber"]);
                }
                reader2.Close();
                SqlDataReader reader = sc.ExecuteReader();
                while (reader.Read())
                {
                   LotteryStudent s= new LotteryStudent();
                    s.StudentID= (string)reader["StudentID"];
                    string studentMajor = Convert.ToString(reader["MajorType"]);
                    if (studentMajor == major)
                        s.Flag = 1;
                    else
                        s.Flag = 0;
                    all.Add(s);
                }
                reader.Close();
               if(limit<total)
                select(all, total, limit);
                int num = limit < total ? limit : total;
                bool succeed = true;
                string studentid = "";
                string updateSql = "UPDATE SelectInfo SET IsSelected=1 WHERE StudentID=@studentid AND CourseID=@courseid";
                for (int i = 0; i < num; ++i)
                {
                    studentid = all[i].StudentID;
                    SqlTransaction tran = conn.BeginTransaction();
                    try
                    {
                        SqlCommand cmd2 = new SqlCommand(updateSql, conn);
                        cmd2.Connection = conn;
                        cmd2.Transaction = tran;
                        cmd2.Parameters.Add(new SqlParameter("studentid", studentid));
                        cmd2.Parameters.Add(new SqlParameter("courseid", courseid));
                        cmd2.ExecuteNonQuery();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('抽签失败')", true);
                        var message = new JavaScriptSerializer().Serialize(ex.Message.ToString());
                        var script = string.Format("alert({0});", message);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", script, true);
                        tran.Rollback();
                        succeed = false;
                    }
                }
                conn.Close();
                if (succeed)
                {
                    Response.Redirect("ShowDetail.aspx");
                }
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('抽签完成')", true);             
            }
        } 
    }
}