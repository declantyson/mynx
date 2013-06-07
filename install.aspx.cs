using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;
using System.IO;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;

namespace mynx
{
    public partial class install : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public string SaveConnectionString(string a, string b, string c, string d, string e)
        {
            System.Configuration.Configuration webConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
            string connString = "Data Source=" + a + b + ";Initial Catalog=" + c + ";User ID=" + d + ";Password=" + e;
            webConfig.ConnectionStrings.ConnectionStrings["mynxConnectionString"].ConnectionString = connString;
            webConfig.Save();
            return connString;
        }

        public void InitialiseDatabase(string connString)
        {
            SqlConnection connection = new SqlConnection(connString);

            string script = File.ReadAllText(Server.MapPath("/") + "default.sql");

            // split script on GO command
            IEnumerable<string> commandStrings = Regex.Split(script, @"^\s*GO\s*$",
                                     RegexOptions.Multiline | RegexOptions.IgnoreCase);
            try
            {
                connection.Open();
                foreach (string commandString in commandStrings)
                {
                    if (commandString.Trim() != "")
                    {
                        new SqlCommand(commandString, connection).ExecuteNonQuery();
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Response.Redirect("/");
            }
            finally
            {
                connection.Close();
            }
        }

        public void CreateMYNXUser()
        {

        }

        protected void install_Click(object sender, EventArgs e)
        {
            string address = ".";
            if (ipAddress.Text != "")
            {
                address = ipAddress.Text;
            }

            string server = serverType.SelectedValue;
            string database = databaseName.Text;
            string user = databaseUsername.Text;
            string pass = databasePassword.Text;

            string connString = SaveConnectionString(address, server, database, user, pass);
            InitialiseDatabase(connString);
            CreateMYNXUser();
            
            Response.Redirect("/");
        }
    }
}