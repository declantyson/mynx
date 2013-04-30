using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data.Sql;

public partial class Page : System.Web.UI.Page
{
	public string currentTheme = "";
	public string title = "";
	public string data = "";
	public string slug = "";
	public string cat = "";

	protected void Page_PreInit(object sender, EventArgs e)	{
		SqlConnection connection = new SqlConnection(GetConnectionString());
		string sql_string = "SELECT TOP 1 * FROM settings";
        try
		{
			connection.Open();
			SqlDataReader settings_reader = null;
			SqlCommand sql_command = new SqlCommand(sql_string, connection);
			settings_reader = sql_command.ExecuteReader();
			
			while(settings_reader.Read())
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

	    MasterPageFile = "/themes/" + currentTheme + "/master.master";
	}

    protected void Page_Load(object sender, EventArgs e) {        
		cat = Request.QueryString["cat"];
		if(cat != "" && cat != null) {
			cat = "WHERE cat = '" + cat + "'";
		}
		SqlConnection connection = new SqlConnection(GetConnectionString());
		string sql_string = "SELECT * FROM pages " + cat;
        try
		{
			connection.Open();
			SqlDataReader page_reader = null;
			SqlCommand sql_command = new SqlCommand(sql_string, connection);
			page_reader = sql_command.ExecuteReader();
			
			while(page_reader.Read())
			{	
				title = page_reader["title"].ToString();
				slug = page_reader["slug"].ToString();
				data += "<a href='/" + slug + "'>" + title + "</a><br/>";
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
	
	public string GetConnectionString() {
       return System.Configuration.ConfigurationManager.ConnectionStrings["mynxConnectionString"].ConnectionString;
    } 
}