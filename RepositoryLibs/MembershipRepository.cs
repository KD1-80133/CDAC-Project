﻿using EntityModelsLib;
using Microsoft.Data.SqlClient;
using UtilityLib;
namespace RepositoryLib
{
    public class MembershipRepository : IMembershipRepository
    {

        public static string connectionDetails = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=task_mgt;Integrated Security=True";
        public bool ChangePassword(string email, string oldPassword, string newPassword)
        {
            SqlConnection connection = new SqlConnection(connectionDetails);
            connection.Open();
            SqlCommand cmd = new SqlCommand("Update T_User set Password  = @newPassword where EmailId = @email  ", connection);
            cmd.Parameters.AddWithValue("@newPassword", newPassword);
            cmd.Parameters.AddWithValue("@email", email);
            int rowsAffected = cmd.ExecuteNonQuery();
            Console.WriteLine(rowsAffected);
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

        public bool CreateUser(string userName, string password, string mobileNo, string emailId)
        {
            string connctionDetails = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=task_mgt;Integrated Security=True;";

            SqlConnection connection = new SqlConnection(connctionDetails);
            connection.Open();

            string query = "insert into T_User(Name,Password,MobileNo,EmailId) values(@Name,@Password,@MobileNo,@EmailId)";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add(new SqlParameter("@Name", userName));
            command.Parameters.Add(new SqlParameter("@Password", password));
            command.Parameters.Add(new SqlParameter("@MobileNo", mobileNo));
            command.Parameters.Add(new SqlParameter("@EmailId", emailId));

            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            if (rowsAffected == 1)
            {
                //Console.WriteLine("Rows Affected : "+rowsAffected);
                return true;
            }
            else
            {
                //Console.WriteLine("data not entered correctly !!!");
                return false;
            }
        }

        public bool DeleteUser(string emailId)
        {
            string connctionDetails = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=task_mgt;Integrated Security=True;";

            SqlConnection connection = new SqlConnection(connctionDetails);
            connection.Open();

            string query = "delete from T_User where EmailId = @Email";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add(new SqlParameter("Email", emailId));

            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            if (rowsAffected == 1)
            {
                //Console.WriteLine("Rows Affected : "+rowsAffected);
                return true;
            }
            else
            {
                //Console.WriteLine("data not entered correctly !!!");
                return false;
            }
        }


        public string GenerateOTP(string emailId)
        {
            SqlConnection connection = new SqlConnection(connectionDetails);
            connection.Open();

            string query = "select * from T_User where EmailId=@emailId";
            SqlCommand commnd = new SqlCommand(query, connection);
            commnd.Parameters.Add(new SqlParameter("@emailId", emailId));
            SqlDataReader reader = commnd.ExecuteReader();

            int userId = 0;
            while (reader.Read())
            {
                User user = new User();
                user.UserId = Convert.ToInt32(reader["UserId"]);
                userId = user.UserId;
            }
            connection.Close();
            if (userId != 0)
            {
                connection.Open();
                OTP otpGenerate = new OTP();
                string otp = otpGenerate.GetOTP();
                string OtpQuery = "insert into T_OTP_Details(UserId,OTP,GeneratedOn,ValidTill) values(@userId,@otp,@generatedOn,@validTill)";
                SqlCommand cmnd = new SqlCommand(OtpQuery, connection);
                cmnd.Parameters.Add(new SqlParameter("@userId", userId));
                cmnd.Parameters.Add(new SqlParameter("@otp", otp));
                cmnd.Parameters.Add(new SqlParameter("@generatedOn", DateTime.Now));
                cmnd.Parameters.Add(new SqlParameter("@validTill", DateTime.Now.AddSeconds(300)));
                int RowsAffected = cmnd.ExecuteNonQuery();
                connection.Close();
                return otp;
            }
            return string.Empty;

        }

        public IEnumerable<User> GetAllUsers()
        {
            string connctionDetails = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=task_mgt;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connctionDetails);
            connection.Open();

            string query = "select * from T_User";
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();
            List<User> users = new List<User>();

            while (reader.Read())
            {
                User user = new User();
                user.UserId = Convert.ToInt32(reader["UserId"]);
                user.Name = reader["Name"].ToString();
                user.MobileNo = reader["MobileNo"].ToString();
                user.Password = reader["Password"].ToString();
                user.EmailId = reader["EmailId"].ToString();

                
                users.Add(user);
            }

            connection.Close();

            foreach (User u in users)
            {
                Console.WriteLine(u.ToString());
            }
            return users;
        }

        public int GetNumberOfUsersOnline()
        {
            SqlConnection connection = new SqlConnection(connectionDetails);
            connection.Open();
            SqlCommand cmd = new SqlCommand("select count(userId) from T_User where IsOnline = 1", connection);
            int count = (int)cmd.ExecuteScalar();
            return count;
        }

        public User GetUser(string email)
        {
            throw new NotImplementedException();
        }

        public User GetUserByEmail(string emailToMatch)
        {
            SqlConnection connection = new SqlConnection(connectionDetails);
            connection.Open();

            SqlCommand command = new SqlCommand("select * from T_User where EmailId = @email", connection);
            command.Parameters.AddWithValue("@email", emailToMatch);

            SqlDataReader reader = command.ExecuteReader();
            User u = new User();
            if (reader.Read())
            {
                u.UserId = Convert.ToInt32(reader["UserId"]);
                u.EmailId = reader["EmailId"].ToString();
                u.Password = reader["Password"].ToString();
                u.MobileNo = reader["MobileNo"].ToString();
                u.IsOnline = Convert.ToBoolean(reader["IsOnline"]);
                u.IsLocked = Convert.ToBoolean(reader["IsLocked"]);
                u.RoleId = Convert.ToInt32(reader["RoleId"]);
                u.Name = reader["Name"].ToString();
                u.AdharNumber = reader["AdharNumber"].ToString();
                u.Address = reader["Address"].ToString();
            }
            return u;
        }

        public User GetUserByMobileNo(string mobileNo)
        {

            SqlConnection connection = new SqlConnection(connectionDetails);
            connection.Open();

            SqlCommand command = new SqlCommand("select * from T_User where MobileNo = @mobileNo", connection);
            command.Parameters.AddWithValue("@mobileNo", mobileNo);

            SqlDataReader reader = command.ExecuteReader();
            User u = new User();
            if (reader.Read())
            {
                u.UserId = Convert.ToInt32(reader["UserId"]);
                u.EmailId = reader["EmailId"].ToString();
                u.Password = reader["Password"].ToString();
                u.MobileNo = reader["MobileNo"].ToString();
                u.IsOnline = Convert.ToBoolean(reader["IsOnline"]);
                u.IsLocked = Convert.ToBoolean(reader["IsLocked"]);
                u.RoleId = Convert.ToInt32(reader["RoleId"]);
                u.Name = reader["Name"].ToString();
            }
            return u;

        }

        public bool LockUser(string email)
        {
            SqlConnection connection = new SqlConnection(connectionDetails);
            connection.Open();

            SqlCommand command = new SqlCommand("update T_User set IsLocked = @value where EmailId = @email", connection);
            command.Parameters.AddWithValue("@value", true);
            command.Parameters.AddWithValue("@email", email);

            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
                return true;
            else
                return false;
        }

        public bool ResetPassword(string emailId, string otp, string newPassword)
        {
            SqlConnection connection = new SqlConnection(connectionDetails);
            connection.Open();

            string query = "select UserId from T_User where EmailId=@emailId";
            SqlCommand commnd = new SqlCommand(query, connection);
            commnd.Parameters.Add(new SqlParameter("@emailId", emailId));
            int userId = (int)commnd.ExecuteScalar();
            connection.Close();

            connection.Open();
            string query3 = "select count(*) from T_OTP_Details where OTP=@otp and GetDate() between GeneratedOn and ValidTill";
            SqlCommand commd3 = new SqlCommand(query3, connection);
            commd3.Parameters.Add(new SqlParameter("@otp", otp));
            int i = (int)commd3.ExecuteScalar();
            if (i > 0)
            {
                string query2 = "update T_User set Password=@newPassword where UserId=@userId AND EXISTS (select 1 from T_OTP_Details where OTP=@otp AND GETDATE() <= ValidTill)";
                SqlCommand comnd = new SqlCommand(query2, connection);
                comnd.Parameters.Add(new SqlParameter("@newPassword", newPassword));
                comnd.Parameters.Add(new SqlParameter("@userId", userId));
                comnd.Parameters.Add(new SqlParameter("@otp", otp));
                int RowsAffected = comnd.ExecuteNonQuery();
                connection.Close();

                if (RowsAffected >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool UnlockUser(string email)
        {
            SqlConnection connection = new SqlConnection(connectionDetails);
            connection.Open();

            SqlCommand command = new SqlCommand("update T_User set IsLocked = @value where EmailId = @email", connection);
            command.Parameters.AddWithValue("@value", 0);
            command.Parameters.AddWithValue("@email", email);

            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
                return true;
            else
                return false;

        }

        public bool UpdateUser(User user)
        {
            SqlConnection connection = new SqlConnection(connectionDetails);
            connection.Open();

            string query = "update T_User set EmailId=@emailId,MobileNo=@mobileNo,Name=@name where UserId=@userId";
            SqlCommand commnd = new SqlCommand(query, connection);
            commnd.Parameters.Add(new SqlParameter("@emailId", user.EmailId));
            commnd.Parameters.Add(new SqlParameter("@mobileNo", user.MobileNo));
            commnd.Parameters.Add(new SqlParameter("@name", user.Name));
            commnd.Parameters.Add(new SqlParameter("@userId", user.UserId));

            int RowsAffected = commnd.ExecuteNonQuery();
            connection.Close();

            if (RowsAffected >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ValidateUser(string emailId, string password)
        {
            int userId = 0;
            string passwd = string.Empty;

            SqlConnection connection = new SqlConnection(connectionDetails);

            connection.Open();

            string query = "SELECT UserId, Password FROM T_User WHERE EmailId = @emailId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(new SqlParameter("@emailId", emailId));

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                userId = Convert.ToInt32(reader["UserId"]);
                passwd = reader["Password"].ToString();
            }


            SqlConnection conn = new SqlConnection(connectionDetails);

            conn.Open();

            if (passwd == password && userId > 0)
            {
                string updateOnlineQuery = "UPDATE T_User SET IsOnline = 1 WHERE UserId = @UserId";
                SqlCommand commandOnline = new SqlCommand(updateOnlineQuery, conn);
                commandOnline.Parameters.Add(new SqlParameter("@UserId", userId));
                commandOnline.ExecuteNonQuery();
                Console.WriteLine("User is Online.");
                return true;
            }
            else
            {
                string updateOfflineQuery = "UPDATE T_User SET IsOnline = 0 WHERE UserId = @UserId";
                SqlCommand commandOffline = new SqlCommand(updateOfflineQuery, conn);
                commandOffline.Parameters.Add(new SqlParameter("@UserId", userId));
                commandOffline.ExecuteNonQuery();
                Console.WriteLine("User is Offline.");
                return false;
            }
        }
    }
    }
