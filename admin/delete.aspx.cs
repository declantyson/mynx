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
	public string currentTheme = "";
	public string pageTitle = "";
	public string slug = "";
	public string text = "";
	public string cat = "";
	public string id = "";

	protected void Page_PreInit(object sender, EventArgs e)	{

	}

    protected void Page_Load(object sender, EventArgs e) {        
    	slug = Request.QueryString["page"];
    	SqlConnection connection = new SqlConnection(GetConnectionString());

		try {
            connection.Open();
			using (SqlCommand cmd = new SqlCommand("DELETE FROM pages WHERE slug=@slug", connection))
			{
			cmd.Parameters.AddWithValue("@slug", slug);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
			}
        } catch (System.Data.SqlClient.SqlException ex) {
            string msg = "=( Something's not right! ";
            msg += ex.Message;
            throw new Exception(msg);
        } finally {
            connection.Close();
            Response.Redirect("/admin/pages/");
        }
    }
	
	public string GetConnectionString() {
       return System.Configuration.ConfigurationManager.ConnectionStrings["mynxConnectionString"].ConnectionString;
    } 
}