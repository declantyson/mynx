using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data.Sql;

public partial class xampp_Default : System.Web.UI.Page
{
	public string currentTheme = "ajaxy"; // this will be defined in the database later on

	protected void Page_PreInit(object sender, EventArgs e)	{
	    MasterPageFile = "/themes/" + currentTheme + "/master.master";
	}

    protected void Page_Load(object sender, EventArgs e) {        

    }
	
	public string GetConnectionString() {
       return System.Configuration.ConfigurationManager.ConnectionStrings["mynxConnectionString"].ConnectionString;
    } 
}