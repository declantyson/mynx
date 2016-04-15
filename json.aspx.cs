using System;
using System.Globalization;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data.Sql;

    public partial class json : System.Web.UI.Page
    {
        public string currentTheme = "";
        public string title = "";
        public string pageTitle = "";
		public string text = "";
        public string data = "";
        public string slug = "";
        public string cat = "";
		public string className = "";

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
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            cat = Request.QueryString["cat"];
            if (cat != "" && cat != null)
            {
				className = cat;
                cat = cat.Replace("-", " ");
                cat = ToTitleCase(cat);
                pageTitle = cat;
                cat = String.Format("AND cat = '{0}'", cat);
            }
            else
            {
                pageTitle = "Page Directory";
            }
            SqlConnection connection = new SqlConnection(GetConnectionString());
            string sql_string = String.Format("SELECT * FROM pages WHERE active = 1 AND published = 1 {0} ORDER BY date_published DESC", cat);
            try
            {
                connection.Open();
                SqlDataReader page_reader = null;
                SqlCommand sql_command = new SqlCommand(sql_string, connection);
                page_reader = sql_command.ExecuteReader();
				int count = 0;
				data = "[";
                while (page_reader.Read())
                {
					if(count > 0) data += ",";
                    title = page_reader["title"].ToString();
					text = RemoveHTML(page_reader["text"].ToString());
					string date = page_reader["date_published"].ToString();
					if(text.Length > 250) {
						text = text.Substring(0, 250) + "...";
					}
                    slug = page_reader["slug"].ToString();
					text = text.Replace("'", "&rsquo;");
                    data += String.Format("{{ \"title\" : \"{0}\", \"slug\" : \"{1}\", \"image\":\"/assets/background-images/{2}.jpg, \"date\" : \"{3}\", \"intro\":\"{4}\" }}", title, slug, slug, date, text.Trim());
					count++;
                }
                data += "]";
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
				Response.ContentType = "application/json; charset=utf-8";
				Response.Write(data);
            }
        }

        public string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["mynxConnectionString"].ConnectionString;
        }
		
		public bool IsAjaxRequest(HttpRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            return (request["X-Requested-With"] == "XMLHttpRequest") || ((request.Headers != null) && (request.Headers["X-Requested-With"] == "XMLHttpRequest"));
        }

        public string ToTitleCase(string inputString)
        {
            System.Globalization.TextInfo txtInfo = System.Globalization.CultureInfo.CurrentCulture.TextInfo;
            return txtInfo.ToTitleCase(inputString);
        }
		
		public string RemoveHTML(string strText) {
			int nPos1;
			int nPos2;

			nPos1 = strText.IndexOf("<");
			while (nPos1 != -1) {
				nPos2 = strText.IndexOf(">",nPos1 + 1);
				if (nPos2 != -1) {
					strText = strText.Remove(nPos1,nPos2-nPos1+1);
				}else{
					return strText; 
				}
				nPos1 = strText.IndexOf("<");
			}
			return strText;
		} 
    }