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

public partial class Page : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e) {        
        
    }

    protected void uploaded(object sender, UploaderEventArgs e)
    {
        string fn = Path.Combine(Server.MapPath("~/assets"), e.FileName);
        e.CopyTo(fn);
        feedback.Text += "Successfully uploaded " + e.FileName;
    }
	
	public string GetConnectionString() {
       return System.Configuration.ConfigurationManager.ConnectionStrings["mynxConnectionString"].ConnectionString;
    } 
}