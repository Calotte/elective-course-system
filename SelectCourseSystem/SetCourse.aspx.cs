using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelectCourseSystem
{
    public partial class SetCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["CourseName"] = GridView1.SelectedRow.Cells[2].Text;
            Session["CourseID"] = GridView1.SelectedRow.Cells[1].Text;
            Response.Redirect("ShowDetail.aspx");
        }

        protected void LinqDataSource1_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {

        }
    }
}