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
	public int block_sidebar = 0;

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
				block_sidebar = Convert.ToInt32(settings_reader["block_sidebar"]);
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