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
    public partial class CourseIO : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void LinqDataSource1_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            RemoteDatabaseDataContext rdc = new RemoteDatabaseDataContext();
            e.Result=from p in rdc.rCourse
                     join rcp in rdc.rCoursePlan on p.CourseID equals rcp.CourseID
                     select new
                     {
                         p.CourseID, p.CourseName,p.Credit,
                         Room = rcp.DetailLocation,
                         Teacher =rcp.TeacherName, 
                         TimeAndRoom=rcp.TimeAndRoom, ElectiveStartTime=rcp.ElectiveStartTime,
                         ElectiveEndTime=rcp.ElectiveStartTime,maxNumber=rcp.MaxNumber,
                        Major=rcp.OptionalProfessional
                     };
        }

        protected void Button1_Click(object sender, EventArgs e)//从学院数据库获取原始课程数据导入本地数据库
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ustcsseConnectionString"].ConnectionString);
            conn.Open();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                for (int i = 0; i < GridView1.Rows.Count; ++i)
                {
                    string sqlStr = "";
                    string CourseID = GridView1.Rows[i].Cells[0].Text.Trim().ToString();
                    string CourseName = GridView1.Rows[i].Cells[1].Text.Trim().ToString();
                    string Credit = GridView1.Rows[i].Cells[2].Text.Trim().ToString();
                    string Room = GridView1.Rows[i].Cells[3].Text.Trim().ToString();
                    string Teacher = GridView1.Rows[i].Cells[4].Text.Trim().ToString();
                    string TimeAndRoom = GridView1.Rows[i].Cells[5].Text.Trim().ToString();
                    string Start = GridView1.Rows[i].Cells[6].Text.Trim().ToString();
                    string End = GridView1.Rows[i].Cells[7].Text.Trim().ToString();
                    string MaxNumber = GridView1.Rows[i].Cells[8].Text.Trim().ToString();
                    string MajorType = GridView1.Rows[i].Cells[9].Text.Trim().ToString();
                    string current = "0";
                    sqlStr = "INSERT  INTO CourseInfo (CourseID,CourseName,Credit,Room,TeacherName,TimeAndRoom,ElectiveStartTime,ElectiveEndTime,CurrentNumber,MaxNumber,MajorType) VALUES ('" + CourseID + "','" + CourseName + "','" + Credit + "','" + Room + "','" + Teacher +"','"+ TimeAndRoom + "','" + Start + "','" + End+"','"+ current + "','" + MaxNumber + "','" + MajorType + "')";
                    SqlCommand comm = new SqlCommand(sqlStr, conn);
                    comm.CommandText = sqlStr;
                    comm.Connection = conn;
                    comm.Transaction = tran;
                    comm.ExecuteNonQuery();
                }
                tran.Commit();              
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('导入信息成功，请勿重复导入！')", true);
            }
            catch (Exception ex)
            {           
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('对不起，不能重复导入')", true);
                tran.Rollback();
            }
            finally
            {
                conn.Close();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ustcsseConnectionString"].ConnectionString);
            conn.Open();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                string sqlStr = "DELETE FROM CourseInfo";
                string sqlStr2 = "DELETE FROM SelectInfo";
                SqlCommand comm = new SqlCommand(sqlStr, conn);              
                comm.CommandText = sqlStr;           
                comm.Connection = conn;                
                comm.Transaction = tran;
                comm.ExecuteNonQuery();
                SqlCommand comm2 = new SqlCommand(sqlStr2, conn);
                comm2.CommandText = sqlStr2;
                comm2.Connection = conn;
                comm2.Transaction = tran;            
                comm2.ExecuteNonQuery();
                tran.Commit();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('数据已清空！')", true);
            }
            catch (Exception ex)
            {
                var message = new JavaScriptSerializer().Serialize(ex.Message.ToString());
                var script = string.Format("alert({0});", message);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage",script, true);
                tran.Rollback();
            }finally
            {
                conn.Close();
            }
        }
    }
}
