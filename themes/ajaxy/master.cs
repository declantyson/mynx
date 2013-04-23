using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data.Sql;

public partial class MasterPage : System.Web.UI.MasterPage
{

	public string sidebar_code = "";
	public string toolbar_code = "";
	public string footer_code = "";
	public int block_sidebar = 0;
	public int block_toolbar = 0;
	public int block_footer = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
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
				sidebar_code = settings_reader["sidebar_code"].ToString();
				toolbar_code = settings_reader["toolbar_code"].ToString();
				footer_code = settings_reader["footer_code"].ToString();
				block_sidebar = Convert.ToInt32(settings_reader["block_sidebar"]);
				block_toolbar = Convert.ToInt32(settings_reader["block_toolbar"]);
				block_footer = Convert.ToInt32(settings_reader["block_footer"]);
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