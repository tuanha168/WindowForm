using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Practice1.Models;

namespace Practice1
{
    class DBConnection
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public DBConnection()
        {
            Initialize();
        }

        private void Initialize()
        {
            server = "localhost";
            database = "practice";
            uid = "cirno";
            password = "Tuan1995";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public string Register(string userName, string password)
        {
            var cryptPassword = this.Crypt(password);
            string query = "INSERT INTO User (username, password) VALUES('" + userName + "', '" + cryptPassword + "')";

            if (this.OpenConnection() == true)
            {
                String message = "Register Successful";
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    message = ex.Message;
                }
                finally
                {
                    this.CloseConnection();
                }
                return message;
            }
            else
            {
                return "Database Not Found";
            }
        }
        public string Login(string userName, string password)
        {
            var cryptPassword = this.Crypt(password);
            string query = "SELECT * FROM User where username = '" + userName + "' and password = '" + cryptPassword + "'";

            //Open connection
            if (this.OpenConnection() == true)
            {
                string message = "Login Success";
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (!dataReader.Read())
                    {
                        message = "Login fail";
                    }
                    dataReader.Close();
                }
                catch (MySqlException ex)
                {
                    message = ex.Message;
                }
                finally
                {
                    this.CloseConnection();
                }
                return message;
            }
            else
            {
                return "Database Not Found";
            }
        }//Select statement
        public void SelectEmployee(ref List<Employee> employees)
        {
            string query = "SELECT * FROM practice1";
            employees = new List<Employee> { };
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    employees.Add(new Employee(dataReader["name"].ToString(), dataReader["roles"].ToString(), dataReader["birthyear"].ToString()));
                }
                dataReader.Close();
                this.CloseConnection();
            }
        }
        private string Crypt(string text)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(text);
            return Convert.ToBase64String(plainTextBytes);
        }

        private string Decrypt(string base64EncodedData)
        {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
