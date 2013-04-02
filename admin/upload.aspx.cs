using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data.Sql;

public partial class Page : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e) {        

    }

    protected void upload_it(object sender, EventArgs e)
    {
        if (the_file.HasFile && the_file.PostedFile.ContentType.Substring(0,5) == "image") {
            try {
            	string fn = Path.Combine(Server.MapPath("~/assets"), the_file.FileName);
                the_file.SaveAs(fn);
                feedback.Text = "<p>File successfully uploaded.</p>" +
                     the_file.PostedFile.FileName + "<br>" +
                     the_file.PostedFile.ContentLength + " kb<br>" +
                     "Content type: " +
                     the_file.PostedFile.ContentType;
            } catch (Exception ex) {
                feedback.Text = ex.Message;
            }
        } else if(the_file.PostedFile.ContentType.Substring(0,5) != "image") {
        	 feedback.Text = "<p>That's not an image!</p>";
        }
    }
	
	public string GetConnectionString() {
       return System.Configuration.ConfigurationManager.ConnectionStrings["mynxConnectionString"].ConnectionString;
    } 
}