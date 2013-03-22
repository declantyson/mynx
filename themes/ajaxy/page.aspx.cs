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
	public string title = "";
	public string data = "";
	public string slug = "";

	protected void Page_PreInit(object sender, EventArgs e)	{

	}

    protected void Page_Load(object sender, EventArgs e) {        
		slug = Request.QueryString["page"];
		SqlConnection connection = new SqlConnection(GetConnectionString());
		string sql_string = "SELECT TOP 1 * FROM pages WHERE slug = '" + slug + "'";
        try
		{
			connection.Open();
			SqlDataReader page_reader = null;
			SqlCommand sql_command = new SqlCommand(sql_string, connection);
			page_reader = sql_command.ExecuteReader();
			
			while(page_reader.Read())
			{	
				title = page_reader["title"].ToString();
				data = page_reader["text"].ToString();
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