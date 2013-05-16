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

namespace mynx.widgets
{
    public partial class imageSlider : widgetControl
    {
        public string slideshowItems = "";

        protected void Page_Load(object sender, EventArgs e)
        {
           this.text = "Add an image slider";
           this.type = "Content";
           this.code = "<div class='col edit-col col-100 movable resizable widget content-widget image-slider' data-name='imageSlider'><select data-paramname='album' style='display:block'>";

           SqlConnection connection = new SqlConnection(GetConnectionString());
           string sql_string = "SELECT * FROM uploads";
           try
           {
               connection.Open();
               SqlDataReader album_reader = null;
               SqlCommand sql_command = new SqlCommand(sql_string, connection);
               album_reader = sql_command.ExecuteReader();

               while (album_reader.Read())
               {
                   this.code += "<option>" + album_reader["album"].ToString() + "</option>";
                   slideshowItems += "<div class='slideshow-item'><img src='" + album_reader["filepath"].ToString() + "'/></div>";
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

           this.code += "</select></div>";

            
        }

        public string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["mynxConnectionString"].ConnectionString;
        }
    }
}