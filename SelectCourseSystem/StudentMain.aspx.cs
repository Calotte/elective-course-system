using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelectCourseSystem
{
    public partial class StudentMain : System.Web.UI.Page
    {
        private string stuID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Student"] == null)
            {
                Response.Write("<script>parent.window.location.href='Login.aspx'</script>");
            }
            else
            {
                stuID = (string)Session["Student"];
            }                     
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Server.Execute("ElectiveCourse.aspx");  实现在同一页面
            Response.Redirect("ElectiveCourse.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("MySelectedCourse.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void LinqDataSource1_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            ustcsseDataContext db = new ustcsseDataContext();
            e.Result = from p in db.Student
                       where p.StudentID == stuID
                       select p;
        }
    }
}