using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Text;
using System.Security.Cryptography;

namespace mynx.admin
{
    public class auth
    {
        public string HashString(string s)
        {
            MD5 md5 = MD5.Create();
            byte[] b = Encoding.ASCII.GetBytes(s);
            byte[] h = md5.ComputeHash(b);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < h.Length; i++)
            {
                sb.Append(h[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public bool login(string user, string hash)
        {
            bool status = false;
            string session_key = "";
            SqlConnection connection = new SqlConnection(GetConnectionString());
            try
            {
                connection.Open();
                string sql_string = String.Format("SELECT * FROM users WHERE user_name = '{0}'", user);
                SqlDataReader user_reader = null;
                SqlCommand sql_command = new SqlCommand(sql_string, connection);
                user_reader = sql_command.ExecuteReader();

                while (user_reader.Read())
                {
                   if(hash == user_reader["user_pass"].ToString()) {
                       status = true;
                   }
                   session_key = user_reader["user_session"].ToString();
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
            }

            if (status == true)
            {
                HttpContext.Current.Session["user_session"] = session_key; 
            }

            return status;
        }

        public void enforceAuthentication()
        {
            var Session = HttpContext.Current.Session;
            if (Session["user_session"] == null && HttpContext.Current.Request.RawUrl != "/login/")
            {
                HttpContext.Current.Response.Redirect("/login/");
            }
        }

        public string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["mynxConnectionString"].ConnectionString;
        }
    }
}