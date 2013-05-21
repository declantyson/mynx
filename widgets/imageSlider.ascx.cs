using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
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
        public List<string> albums = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
           this.text = "Add an image slider";
           this.type = "Content";
           this.code = "<div class='col edit-col col-100 movable resizable widget content-widget image-slider' data-name='imageSlider'><select data-paramname='album' style='display:block'>";

           // Get a list of all albums in database

           SqlConnection connection = new SqlConnection(GetConnectionString());
           string sql_string = "SELECT * FROM uploads";
           string inputs = "";
           int inputCount = 0;
           try
           {
               connection.Open();
               SqlDataReader album_reader = null;
               SqlCommand sql_command = new SqlCommand(sql_string, connection);
               album_reader = sql_command.ExecuteReader();

               while (album_reader.Read())
               {
                   string a = album_reader["album"].ToString();
                   if (!albums.Any(a.Contains))
                   {
                       this.code += "<option>" + a + "</option>";
                       albums.Add(a);
                   }
                   inputs += "<div class='slideshow-editor' data-album='" + a + "'><img src='" + album_reader["filepath"].ToString() + "' style='width:33%;float:left;'/><label style='width:33%'>Link:</label><input type='text' style='width:33%' data-paramname='link" + inputCount + "'/><div class='clear'></div></div>";
                   inputCount++;
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

           this.code += "</select>" + inputs + "</div>";

           // Here comes the hideous inline JS for the fancy CMS implementation. There must be a better way to do this!

           this.code += "<scr\'+\'ipt>";
           this.code += "function linkEditor($el) { v=$el.val(); $('.slideshow-editor').hide(); $el.siblings('.slideshow-editor[data-album=' + v + ']').show(); }";
           this.code += "linkEditor($('.image-slider select'));";
           this.code += "$('.image-slider select').on('change', function(){ linkEditor($(this)); });";
           this.code += "preRasterize.imageSliderPrep = function(){ $('.slideshow-editor img, .slideshow-editor label, .slideshow-editor .clear, .slideshow-editor input:hidden').remove(); };";
           this.code += "</scr\'+\'ipt>";

           // The actual slideshow

           string thisAlbum = "";
           if (Regex.Split(this.parameters, "==").Length > 1)
           {
               
               thisAlbum = this.parameters.Split('@')[1];
               thisAlbum = Regex.Split(thisAlbum, "==")[1];

               List<string> links = new List<string>(this.parameters.Split('@'));
               links.RemoveRange(0, 2);
               string[] linksArray = links.ToArray();
               int linkCount = 0;

               string slideshow_string = "SELECT * FROM uploads WHERE album = '" + thisAlbum + "'";
               try
               {
                   connection.Open();
                   SqlDataReader item_reader = null;
                   SqlCommand sql_command = new SqlCommand(slideshow_string, connection);
                   item_reader = sql_command.ExecuteReader();

                   while (item_reader.Read())
                   {
                       slideshowItems += "<a href='" + Regex.Split(linksArray[linkCount], "==")[1] + "'><div class='slideshow-item'><img src='" + item_reader["filepath"].ToString() + "' alt='" + item_reader["alt"].ToString() + "'/></div></a>";
                       linkCount++;
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
        }

        public string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["mynxConnectionString"].ConnectionString;
        }
    }
}