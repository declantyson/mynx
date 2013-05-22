using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data.Sql;
using CuteWebUI;

namespace mynx.widgets {

    public partial class uploadBackgroundImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void uploaded(object sender, UploaderEventArgs e)
        {
            string dir = Path.Combine(Server.MapPath("~/assets/featured-images"));
            string slug = uploadTarget.Value + "." + e.FileName.Split('.')[1];
            System.IO.Directory.CreateDirectory(dir);
            string fn = Path.Combine(dir, slug);
            e.CopyTo(fn);
            string browserFriendlyUrl = "/assets/featured-images/" + slug;
            feedback.Text = "<div class='col-content'><img src='" + browserFriendlyUrl + "'/></div>";

            SqlConnection connection = new SqlConnection(GetConnectionString());

            try
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT into uploads (filepath, album) VALUES (@path, @album)", connection))
                {
                    cmd.Parameters.AddWithValue("@path", browserFriendlyUrl);
                    cmd.Parameters.AddWithValue("@album", " ");
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "=( Something's not right! ";
                feedback.Text += ex.Message;
            }
            finally
            {
                connection.Close();
            }

            Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "bgUploaded()", true);
        }

        public string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["mynxConnectionString"].ConnectionString;
        } 
    }
}