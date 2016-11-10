using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Drawing;
using System.Drawing.Imaging;

using CuteWebUI;

namespace mynx.widgets {

    public partial class uploadBackgroundImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void uploaded(object sender, EventArgs e)
        {
            string dir = Path.Combine(Server.MapPath("~/assets/background-images"));
            string slug = uploadTarget.Value + "." + uploadFile.FileName.Split('.')[1];
            System.IO.Directory.CreateDirectory(dir);
            string fn = Path.Combine(dir, slug);
            string browserFriendlyUrl = "/assets/background-images/" + slug;

            SqlConnection connection = new SqlConnection(GetConnectionString());

            try
            {
                uploadFile.SaveAs(fn);
                feedback.Text = "<div class='col-content'><img src='" + browserFriendlyUrl + "'/></div>";
            }
            catch (Exception ex)
            {
                string msg = "=( Something's not right! ";
                feedback.Text += ex.Message;
            }
            finally
            {
                var savedImage = System.Drawing.Image.FromFile(fn);
                var newImage = new Bitmap(225, 150);
                Graphics.FromImage(newImage).DrawImage(savedImage, 0, 0, 225, 150);

                string featDir = Path.Combine(Server.MapPath("~/assets/featured-images"));
                System.IO.Directory.CreateDirectory(featDir);
                string featFn = Path.Combine(featDir, slug);
                newImage.Save(featFn, ImageFormat.Jpeg);
            }

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