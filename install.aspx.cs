﻿using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using mynx.admin;

namespace mynx
{
    public partial class install : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public string SaveConnectionString(string a, string b, string c, string d, string e)
        {
            System.Configuration.Configuration webConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
            string connString = String.Format("Data Source={0}{1};Initial Catalog={2};User ID={3};Password={4}", a, b, c, d, e);
            webConfig.ConnectionStrings.ConnectionStrings["mynxConnectionString"].ConnectionString = connString;
            webConfig.Save();
            return connString;
        }

        public void InitialiseDatabase(string connString)
        {
            SqlConnection connection = new SqlConnection(connString);

            string script = File.ReadAllText(Server.MapPath("/") + "default.sql");

            // split script on GO command
            IEnumerable<string> commandStrings = Regex.Split(script, @"^\s*GO\s*$",
                                     RegexOptions.Multiline | RegexOptions.IgnoreCase);
            try
            {
                connection.Open();
                foreach (string commandString in commandStrings)
                {
                    if (commandString.Trim() != "")
                    {
                        new SqlCommand(commandString, connection).ExecuteNonQuery();
                    }
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
        }

        public void CreateMYNXUser(string connString)
        {
            SqlConnection connection = new SqlConnection(connString);
            auth a = new auth();
            string pass = a.HashString("my" + mynxPassword.Text + "nx");
            try
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO users (user_name,user_pass,user_session) VALUES (@name,@pass,@session)", connection))
                {
                    cmd.Parameters.AddWithValue("@name", mynxUsername.Text);
                    cmd.Parameters.AddWithValue("@pass", pass);
                    cmd.Parameters.AddWithValue("@session", "session_cookie");
                    
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
            }
        }

        protected void install_Click(object sender, EventArgs e)
        {
            int errors = 0;
            string errorString = "";

            if (mynxUsername.Text.Length < 4) { errors++; errorString += "<li>Username is not long enough, must be at least 4 characters</li>"; }
            if (mynxPassword.Text.Length < 6) { errors++; errorString += "<li>Password is not long enough, must be at least 6 characters</li>"; }
            if (mynxPassword.Text != mynxConfirmPassword.Text) { errors++; errorString += "<li>Passwords do not match</li>"; }

            if (errors == 0)
            {
                string address = ".";
                if (ipAddress.Text != "")
                {
                    address = ipAddress.Text;
                }

                string server = serverType.SelectedValue;
                string database = databaseName.Text;
                string user = databaseUsername.Text;
                string pass = databasePassword.Text;

                string connString = SaveConnectionString(address, server, database, user, pass);
                InitialiseDatabase(connString);
                CreateMYNXUser(connString);

                Response.Redirect("/");
            }
            else
            {
                errorString = String.Format("<p>Please attend to the {0} errors listed below</p><ul>{1}</ul>", errors, errorString);
                errormsgs.Controls.Add(new LiteralControl(errorString));
            }
        }
    }
}