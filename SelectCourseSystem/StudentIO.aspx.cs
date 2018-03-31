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
    public partial class DataIO : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ustcsseConnectionString"].ConnectionString);
            conn.Open();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                for(int i = 0; i < GridView1.Rows.Count; ++i)
                {
                    string sqlStr = "";
                    SqlCommand comm = new SqlCommand(sqlStr, conn);
                    string StudentID = GridView1.Rows[i].Cells[0].Text.Trim().ToString();
                    string psw = "123456";
                    string Name= GridView1.Rows[i].Cells[1].Text.Trim().ToString();
                    string SchoolYear= GridView1.Rows[i].Cells[2].Text.Trim().ToString();
                    string MajorType= GridView1.Rows[i].Cells[3].Text.Trim().ToString();
                    sqlStr = "INSERT  INTO Student (StudentID,psw,Name,SchoolYear,MajorType) VALUES ('" + StudentID + "','" + psw + "','" + Name + "','" + SchoolYear +"','"+ MajorType+ "')";
                    comm.CommandText = sqlStr;
                    comm.Connection = conn;
                    comm.Transaction = tran;
                    comm.ExecuteNonQuery();
                }
                tran.Commit();
                //Response.Write("<script>alert('导入成功！请勿重复导入！');</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('导入信息成功，请勿重复导入！')", true);
            }
            catch(Exception ex)
            {
                //Response.Write("导入失败，失败原因：" + ex.Message);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('对不起，不能重复导入')", true);
                tran.Rollback();
            }
            finally
            {
                conn.Close();
            }
        }

        protected void LinqDataSource1_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            RemoteDatabaseDataContext rdc = new RemoteDatabaseDataContext();
            e.Result = from p in rdc.rStudent
                       join br in rdc.rMajorType on p.RMajorType equals br.MajorTypeID
                       select new
                       {
                           p.RStuNo,
                           p.RName,
                           p.SchoolYear,
                           Major = br.MajorTypeName                         
                       };
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ustcsseConnectionString"].ConnectionString);
            conn.Open();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                string sqlStr = "DELETE FROM Student";
                SqlCommand comm = new SqlCommand(sqlStr, conn);
                comm.CommandText = sqlStr;
                comm.Connection = conn;
                comm.Transaction = tran;
                comm.ExecuteNonQuery();
                tran.Commit();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('数据已清空！')", true);
            }
            catch (Exception ex)
            {
                Response.Write("清空失败，失败原因：" + ex.Message);
                tran.Rollback();
            }
            finally
            {
                conn.Close();
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {         
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ustcsseConnectionString"].ConnectionString);
            conn.Open();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                int setCredit = Convert.ToInt32(TextBox1.Text);
                string updateStu = "UPDATE Student SET maxCredit=@setCredit";
                SqlCommand cmd = new SqlCommand(updateStu, conn);
                cmd.Connection = conn;
                cmd.Transaction = tran;
                cmd.Parameters.Add(new SqlParameter("setCredit", setCredit));
                cmd.ExecuteNonQuery();
                tran.Commit();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SuccessMessage", "alert('更改成功')", true);
            }
            catch(Exception ex)
            {
                var message = new JavaScriptSerializer().Serialize("更改失败，原因：" + ex.Message.ToString());
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