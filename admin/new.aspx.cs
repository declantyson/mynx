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
    public partial class _new : System.Web.UI.Page
    {
        public string currentTheme = "";
        public string pageTitle = "";
        public string catOptions = "";
        public string slug = "";
        public string text = "";
        public string id = "";
        public string cat = "";
        public int count = 0;

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

            try
            {
                connection.Open();
                string sql_string = "SELECT DISTINCT cat FROM pages";
                SqlDataReader page_reader = null;
                SqlCommand sql_command = new SqlCommand(sql_string, connection);
                page_reader = sql_command.ExecuteReader();
                string c = "";

                while (page_reader.Read())
                {
                    c = page_reader["cat"].ToString();
                    catOptions += String.Format("<option value='{0}'>{1}</option>", c.Replace(" ", "_"), c);
                }

                text = text.Replace("\"", "'");
                text = text.Trim();
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
            }
        }

        protected void update_page(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(GetConnectionString());

            try
            {
                connection.Open();
                string sql_string = String.Format("SELECT * FROM pages WHERE slug = '{0}'", slug);
                SqlDataReader page_reader = null;
                SqlCommand sql_command = new SqlCommand(sql_string, connection);
                page_reader = sql_command.ExecuteReader();

                while (page_reader.Read())
                {
                    pageTitle = page_reader["title"].ToString();
                    id = page_reader["id"].ToString();
                    slug = page_reader["slug"].ToString();
                    text = page_reader["text"].ToString();
                    count++;
                }

                text = text.Replace("\"", "'");
                text = text.Trim();
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
                if (count == 0)
                {
                    try
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO pages (title,slug,text,cat,meta_desc,meta_keys,date_published,date_updated,active,published) VALUES (@pageTitle,@slug,@text,@cat,@desc,@keys,@date,@date,1,1)", connection))
                        {
                            cmd.Parameters.AddWithValue("@pageTitle", Request["title"]);
                            cmd.Parameters.AddWithValue("@slug", Request["slug"]);
                            cmd.Parameters.AddWithValue("@desc", Request["desc"]);
                            cmd.Parameters.AddWithValue("@keys", Request["keys"]);
                            cmd.Parameters.AddWithValue("@text", Request["text"]);
                            cmd.Parameters.AddWithValue("@date", DateTime.Now);
                            if (Request["cat_drop"] == "new")
                            {
                                cmd.Parameters.AddWithValue("@cat", Request["cat_text"]);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@cat", Request["cat_drop"].Replace("_", " "));
                            }
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
                else
                {
                    error.Text = "<div class='error'>A page already exists with that slug. Please try again.</div>";
                }
            }
        }

        public string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["mynxConnectionString"].ConnectionString;
        } 
    }
}