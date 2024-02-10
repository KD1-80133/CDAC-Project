using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Project_logger
{
    public class LoggerDB : Logger
    {
        public string ConnectionDetails { get; set; }
        public LoggerDB()
        {
            ConnectionDetails = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Project;Integrated Security=True;";
        }

        public LoggerDB(String Connectiondetails)
        {
            this.ConnectionDetails = Connectiondetails;
        }

        public bool LoggerEntry(Exception e)
        {
            SqlConnection connection = new SqlConnection(ConnectionDetails);
            connection.Open();

            string query = "insert into ErrorLogs(Source,Method,ErrorOn,Message,StackTrace) values(@Source,@Method,@ErrorOn,@Message,@StackTrace)";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(new SqlParameter("@Source", e.Source==null ? DBNull.Value:e.Source));
            command.Parameters.Add(new SqlParameter("@Method", "Method"));
            command.Parameters.Add(new SqlParameter("@ErrorOn", DateTime.Now));
            command.Parameters.Add(new SqlParameter("@Message", e.Message));
            command.Parameters.Add(new SqlParameter("@StackTrace", e.StackTrace == null ? DBNull.Value : e.StackTrace));
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            if (rowsAffected == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
