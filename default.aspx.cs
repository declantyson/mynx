using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data.Sql;
using mynx.widgets;

namespace mynx
{
    public partial class _default : System.Web.UI.Page
    {
        public string currentTheme = "";
        public string title = "";
        public string data = "";
        public string slug = "";

        protected void Page_PreInit(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(GetConnectionString());
            string sql_string = "SELECT TOP 1 * FROM settings";
            try
            {
                connection.Open();
                SqlDataReader settings_reader = null;
                SqlCommand sql_command = new SqlCommand(sql_string, connection);
                settings_reader = sql_command.ExecuteReader();

                while (settings_reader.Read())
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

            MasterPageFile = "~/themes/" + currentTheme + "/master.master";
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            slug = Request.QueryString["page"];
            if (slug == "" || slug == null)
            {
                slug = "home";
            }
            SqlConnection connection = new SqlConnection(GetConnectionString());
            string sql_string = "SELECT TOP 1 * FROM pages WHERE slug = '" + slug + "'";
            try
            {
                connection.Open();
                SqlDataReader page_reader = null;
                SqlCommand sql_command = new SqlCommand(sql_string, connection);
                page_reader = sql_command.ExecuteReader();

                while (page_reader.Read())
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

        protected void Page_Load(object sender, EventArgs e)
        {
            renderWidgets(data);
        }

        public string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["mynxConnectionString"].ConnectionString;
        }

        public void renderWidgets(string data)
        {
            string[] dataSplit = Regex.Split(data, "/@/");

            int count = 0;
            foreach (string d in dataSplit)
            {
                if (count % 2 == 1)
                {
                    string[] widgetParams = Regex.Split(d, "/~/");

                    Control ctrl = Page.LoadControl("/widgets/" + widgetParams[0] + ".ascx");
                    dataPanel.Controls.Add(ctrl);
                    ((widgetControl)ctrl).parameters = widgetParams[1];
                }
                else
                {
                    dataPanel.Controls.Add(new LiteralControl(d));
                }
                count++;
            }
        }
    }
}
