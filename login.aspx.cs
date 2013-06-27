using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using mynx.admin;

namespace mynx
{
    public partial class login : System.Web.UI.Page
    {
        public string currentTheme = "";
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (GetConnectionString() == "")
            {
                Response.Redirect("/install/");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["user_session"] = null;
        }

        public void install_Click(object sender, EventArgs e)
        {
            auth a = new auth();
            string hash = a.HashString("my" + mynxPassword.Text + "nx");
            bool status = a.login(mynxUsername.Text, hash);
            if (status == false)
            {
                statusMessage.Text = "Incorrect username/password combination.";
            }
            else
            {
                Response.Redirect("/admin/");
            }
        }

        public string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["mynxConnectionString"].ConnectionString;
        }

    }
}