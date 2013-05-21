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
    public partial class image : System.Web.UI.Page
    {
        public string currentTheme = "";
        public string filePath = "";
        public string album = "";
        public string alt = "";

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
            string image = Request.QueryString["image"];
            id.Value = image;
            SqlConnection connection = new SqlConnection(GetConnectionString());
            string sql_string = "SELECT * FROM uploads WHERE id = '" + image + "'";
            try
            {
                connection.Open();
                SqlDataReader image_reader = null;
                SqlCommand sql_command = new SqlCommand(sql_string, connection);
                image_reader = sql_command.ExecuteReader();

                while (image_reader.Read())
                {
                    filePath = image_reader["filepath"].ToString();
                    album = image_reader["album"].ToString();
                    alt = image_reader["alt"].ToString();
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


        public string GetConnectionString()
        {
           return System.Configuration.ConfigurationManager.ConnectionStrings["mynxConnectionString"].ConnectionString;
        }

        protected void update_image(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(GetConnectionString());
            try
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE uploads SET album=@album,alt=@alt WHERE id= @id", connection))
                {
                    cmd.Parameters.AddWithValue("@id", id.Value);
                    cmd.Parameters.AddWithValue("@album", Request["album"]);
                    cmd.Parameters.AddWithValue("@alt", Request["alt"]);
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
                Response.Redirect("/admin/imagelibrary/");
            }

        } 
    }
}