using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace SelectCourseSystem
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected static Boolean Authentication(string username, string password)
        {
            string sql = "select StudentID, psw from  Student where StudentID='" + username + "' and psw= '" + password + "'";
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ustcsseConnectionString"].ConnectionString);
            System.Data.SqlClient.SqlCommand comm = new System.Data.SqlClient.SqlCommand(sql, con);
            System.Data.SqlClient.SqlDataReader reader;
            con.Open();
            reader = comm.ExecuteReader();
            if (reader.Read())
                return true;
            else
                return false;
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string name = "admin";
            string pass = "1234";
            if (Login1.UserName == name)
            {
                if (name == Login1.UserName && pass == Login1.Password)
                {
                    Manage Mainform = new Manage();
                    Session["Student"] = Login1.UserName;
                    Response.Redirect("Manage.aspx");
                }

            }
            else
            {
                Boolean result;
                result = false;
                result = Authentication(Login1.UserName, Login1.Password);
                ElectiveCourse Mainform = new ElectiveCourse();
                if (result)
                {
                    Session["Student"] = Login1.UserName;
                    Response.Redirect("StudentMain.aspx");
                }

            }
        }


    }
}