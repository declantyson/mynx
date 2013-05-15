using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data.Sql;
using mynx.widgets;

namespace mynx.admin
{
    public partial class widgets : System.Web.UI.Page
    {
        public int widgetCount = 0;
        public int installedWidgetCount = 0;
        public string currentTheme = "";
        public List<string> widgetNames = new List<string>();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(GetConnectionString());
            try
            {
                string sql_string = "SELECT TOP 1 * FROM settings";
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

            MasterPageFile = "/themes/" + currentTheme + "/admin.master";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(GetConnectionString());
            try
            {
                string widget_sql = "SELECT * FROM widgets";
                connection.Open();
                SqlDataReader widgets_reader = null;
                SqlCommand widget_command = new SqlCommand(widget_sql, connection);
                widgets_reader = widget_command.ExecuteReader();

                while (widgets_reader.Read())
                {
                    string wn = widgets_reader["widget_name"].ToString();
                    widgetNames.Add(wn);
                    installedwidgetlist.Items.Add(new ListItem(wn, wn));
                    installedWidgetCount++;
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
            DirectoryInfo directory = new DirectoryInfo(System.Web.HttpContext.Current.Server.MapPath("~/widgets/"));
            FileInfo[] files = directory.GetFiles();
            widgetCount = files.Length;
            string[] installedWidgetNames = widgetNames.ToArray();
            foreach (FileInfo file in files)
            {
                string fileNameWithoutExtension = file.Name.Replace(".ascx", "");
                if (file.Extension == ".ascx" && !installedWidgetNames.Contains(fileNameWithoutExtension))
                {
                    widgetlist.Items.Add(new ListItem(fileNameWithoutExtension,fileNameWithoutExtension));
                }
            }
        }

        public string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["mynxConnectionString"].ConnectionString;
        }

        protected void install_widget_Click(Object sender, EventArgs e)
        {
            InstallWidget(widgetlist.SelectedItem.Text);
        }

        protected void reinstall_widget_Click(Object sender, EventArgs e)
        {
            ReinstallWidget(installedwidgetlist.SelectedItem.Text);
        }

        protected void InstallWidget(string w)
        {
            Control ctrl = Page.LoadControl("/widgets/" + w + ".ascx");
            widgetinstallpanel.Controls.Add(ctrl);
            string widgetCode = ((widgetControl)ctrl).code;
            string widgetText = ((widgetControl)ctrl).text;
            string widgetType = ((widgetControl)ctrl).type;

            SqlConnection connection = new SqlConnection(GetConnectionString());
            try
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO widgets (widget_name,widget_code,widget_text,widget_type) VALUES (@name,@code,@text,@type)", connection))
                {
                    cmd.Parameters.AddWithValue("@name", w);
                    cmd.Parameters.AddWithValue("@code", widgetCode);
                    cmd.Parameters.AddWithValue("@text", widgetText);
                    cmd.Parameters.AddWithValue("@type", widgetType);
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "=( Something's not right! ";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                connection.Close();
                Response.Redirect("/admin/widgets/");
            }
        }

        protected void ReinstallWidget(string w)
        {
            Control ctrl = Page.LoadControl("/widgets/" + w + ".ascx");
            widgetinstallpanel.Controls.Add(ctrl);
            string widgetCode = ((widgetControl)ctrl).code;
            string widgetText = ((widgetControl)ctrl).text;
            string widgetType = ((widgetControl)ctrl).type;

            SqlConnection connection = new SqlConnection(GetConnectionString());
            try
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE widgets SET widget_code=@code,widget_text=@text,widget_type=@type WHERE widget_name = @name", connection))
                {
                    cmd.Parameters.AddWithValue("@name", w);
                    cmd.Parameters.AddWithValue("@code", widgetCode);
                    cmd.Parameters.AddWithValue("@text", widgetText);
                    cmd.Parameters.AddWithValue("@type", widgetType);
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "=( Something's not right! ";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                connection.Close();
                Response.Redirect("/admin/widgets/");
            }
        }
    }
}