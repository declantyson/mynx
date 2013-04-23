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
	public string currentTheme = ""; // this will be defined in the database later on
	public int themecount = 0;
	public string existing_sidebar_code;
	public int existing_block_sidebar;

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

	    MasterPageFile = "/themes/" + currentTheme + "/admin.master";
	}

    protected void Page_Load(object sender, EventArgs e) {        
		if(!Page.IsPostBack) {
			DirectoryInfo directory = new DirectoryInfo(System.Web.HttpContext.Current.Server.MapPath("~/themes/"));
        	DirectoryInfo[] dirs = directory.GetDirectories();
        	themecount = dirs.Length;
        	foreach (DirectoryInfo dir in dirs) 
        	{
        		themes.Items.Add(new ListItem(dir.Name, dir.Name));
        	}

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
					existing_sidebar_code = settings_reader["sidebar_code"].ToString();
					existing_block_sidebar = Convert.ToInt32(settings_reader["block_sidebar"]);
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

			sidebar_code.Text = existing_sidebar_code;
			block_sidebar.Checked = intToBool(existing_block_sidebar);
        }
    }

    protected void change_theme_Click(Object sender, EventArgs e) {
        SqlConnection connection = new SqlConnection(GetConnectionString());

		try {
            connection.Open();
			using (SqlCommand cmd =new SqlCommand("UPDATE settings SET current_theme=@theme" + " WHERE settings_id=1", connection))
			{
				cmd.Parameters.AddWithValue("@theme", themes.SelectedItem.Text);
	            cmd.CommandType = System.Data.CommandType.Text;
	            cmd.ExecuteNonQuery();
			}
        } catch (System.Data.SqlClient.SqlException ex) {
            string msg = "=( Something's not right! ";
            msg += ex.Message;
            throw new Exception(msg);
        } finally {
            connection.Close();
            Response.Redirect("/admin/settings");
        }
    }   

    public bool intToBool(int i) {
    	return (i == 1);
    }

    protected void update_blocks_Click(Object sender, EventArgs e) {
	    SqlConnection connection = new SqlConnection(GetConnectionString());

		try {
            connection.Open();
			using (SqlCommand cmd =new SqlCommand("UPDATE settings SET block_sidebar=@bs, sidebar_code=@sc WHERE settings_id=1", connection))
			{
				int i = block_sidebar.Checked ? 1 : 0;
				cmd.Parameters.AddWithValue("@bs", i);
				cmd.Parameters.AddWithValue("@sc", sidebar_code.Text);
	            cmd.CommandType = System.Data.CommandType.Text;
	            cmd.ExecuteNonQuery();
			}
        } catch (System.Data.SqlClient.SqlException ex) {
            string msg = "=( Something's not right! ";
            msg += ex.Message;
            throw new Exception(msg);
        } finally {
            connection.Close();
            Response.Redirect("/admin/settings");
        }
    }
	
	public string GetConnectionString() {
       return System.Configuration.ConfigurationManager.ConnectionStrings["mynxConnectionString"].ConnectionString;
    } 
}