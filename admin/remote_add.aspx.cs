using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Data.SqlClient;
using System.Data.Sql;
using mynx.admin;

namespace mynx.admin
{
    public partial class remote_add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			Response.AppendHeader("Access-Control-Allow-Origin", "*");

			auth a = new auth();	
			// Please hash your passwords before sending the request!
            bool status = a.login(Request.Form["mynxUsername"], Request.Form["mynxPassword"]);
			
            if (status == false)
            {
                Response.Write("Incorrect username/password combination. Please check your settings then try again.");
            }
            else
            {
				// Add page...
		        SqlConnection connection = new SqlConnection(GetConnectionString());
				try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO pages (title,slug,text,cat,meta_desc,meta_keys,date_published,date_updated,active,published) VALUES (@pageTitle,@slug,@text,@cat,@desc,@keys,@date,@date,1,1)", connection))
                    {
                        cmd.Parameters.AddWithValue("@pageTitle", Request.Form["title"]);
                        cmd.Parameters.AddWithValue("@slug", Request.Form["slug"]);
                        cmd.Parameters.AddWithValue("@desc", Request.Form["desc"]);
                        cmd.Parameters.AddWithValue("@keys", Request.Form["keys"]);
                        cmd.Parameters.AddWithValue("@text", Request.Form["text"]);
                        cmd.Parameters.AddWithValue("@date", DateTime.Now);
                        cmd.Parameters.AddWithValue("@cat", Request["cat"]);

                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    string msg = "=( Something's not right! ";
                    msg += ex.Message;
                    throw new Exception(msg);
                }
                finally
                {
                    connection.Close();
                    Response.Write("New page successfully created!");
                }
            }
        }
		
		public string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["mynxConnectionString"].ConnectionString;
        } 
    }
}