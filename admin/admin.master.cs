using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data.Sql;


namespace mynx.admin
{
    public partial class master : System.Web.UI.MasterPage
    {

        public string sidebar_code = "";
        public string jsObject = "";

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

                while (settings_reader.Read())
                {
                    sidebar_code = settings_reader["sidebar_code"].ToString();
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

            getWidgetsForCms();
        }

        public string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["mynxConnectionString"].ConnectionString;
        }

        public void getWidgetsForCms()
        {
            SqlConnection connection = new SqlConnection(GetConnectionString());
            string widget_id = "";
            string widget_name = "";
            string widget_text = "";
            string widget_code = "";
            string widget_type = "";
            string widget_json_object = "";

            string sql_string = "SELECT * FROM widgets";
            try
            {
                connection.Open();
                SqlDataReader widget_reader = null;
                SqlCommand sql_command = new SqlCommand(sql_string, connection);
                widget_reader = sql_command.ExecuteReader();

                while (widget_reader.Read())
                {
                    widget_id = widget_reader["widget_id"].ToString();
                    widget_name = widget_reader["widget_name"].ToString();
                    widget_text = widget_reader["widget_text"].ToString();
                    widget_code = widget_reader["widget_code"].ToString();
                    widget_type = widget_reader["widget_type"].ToString();
                    if(widget_type == "Content") {
                        widget_json_object = "widgetCode";
                    } else if(widget_type == "Option") {
                        widget_json_object = "optionWidgetCode";
                    }
                    jsObject += widget_json_object + "." + widget_name + " = { text : '" + widget_text + "', code : '" + widget_code.Replace("'", "\"").Replace("<scr\"+\"ipt>", "<scr'+'ipt>").Replace("</scr\"+\"ipt>", "</scr'+'ipt>") + "' };\n";
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

    }
}