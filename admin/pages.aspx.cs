using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data.Sql;

namespace mynx.admin
{
    public partial class pages : System.Web.UI.Page
    {
        public string currentTheme = "";
        public string output = "";

        protected void Page_PreInit(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(GetConnectionString());
            string sql_string = "SELECT TOP 1 * FROM settings";
            try
            {
                connection.Open();
                SqlDataReader settings_reader = null;
                SqlCommand sql_command = new SqlCommand(sql_string, connection);
                settings_reader = sql_command.ExecuteReader();

                while (settings_reader.Read())
                {
                    currentTheme = settings_reader["current_theme"].ToString();
                }

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "D'oh, something's not right...";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                connection.Close();
            }

            MasterPageFile = "/themes/" + currentTheme + "/admin.master";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(GetConnectionString());
            string sql_string = "SELECT * FROM pages ORDER BY date_published DESC";
            try
            {
                connection.Open();
                SqlDataReader page_reader = null;
                SqlCommand sql_command = new SqlCommand(sql_string, connection);
                page_reader = sql_command.ExecuteReader();

                while (page_reader.Read())
                {
                    output += String.Format("<tr><td><a href='/admin/edit/{0}'>{1}</a></td><td>{2}</td><td>{3}</td><td><a href='#' class='delete-link' data-del='{4}'>Delete</a></td></tr>", page_reader["slug"].ToString(), page_reader["title"].ToString(), page_reader["slug"].ToString(), Convert.ToDateTime(page_reader["date_published"]).ToString("dd/MM/yyyy"), page_reader["slug"].ToString());
                }

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "D'oh, something's not right...";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                connection.Close();
            }
        }

        protected void update_page(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(GetConnectionString());

            try
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE pages SET title=@pageTitle,slug=@slug,text=@text WHERE id=@id", connection))
                {
                    cmd.Parameters.AddWithValue("@id", Request["id"]);
                    cmd.Parameters.AddWithValue("@pageTitle", Request["title"]);
                    cmd.Parameters.AddWithValue("@slug", Request["slug"]);
                    cmd.Parameters.AddWithValue("@text", Request["text"]);
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
                Response.Redirect("/admin/pages/");
            }
        }

        public string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["mynxConnectionString"].ConnectionString;
        } 
    }
}