 using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLib
{
    public class MembershipRepositry : IMembershipRepository
    {
        public static string connectionDetails = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Project;Integrated Security=True;";
        public bool ChangePassword(string email, string oldPassword, string newPassword)
        {
            SqlConnection connection = new SqlConnection(connectionDetails);
            connection.Open();
            SqlCommand cmd = new SqlCommand("Update T_User set Password=@newPassword where EmailId=@email", connection);
            cmd.Parameters.AddWithValue("@newPassword", newPassword);
            cmd.Parameters.AddWithValue("@email", email);
            int rowAffected = cmd.ExecuteNonQuery();
            connection.Close();
            if(rowAffected==1)
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
            string connectionDeatils = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Project;Integrated Security=True;";
            SqlConnection connection = new SqlConnection(connectionDeatils);
            connection.Open();
            string query = "insert into T_User(Name,Password,MobileNo.EmailId) values(@Name,@Password,@MobileNo,@EmailId)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(new SqlParameter("@Name", userName));
            command.Parameters.Add(new SqlParameter("@Password", password));
            command.Parameters.Add(new SqlParameter("@MobileNo", mobileNo));
            command.Parameters.Add(new SqlParameter("EmailId", emailId));

            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            if(rowsAffected==1)
            {
                return true;
            }
            else {
                return false;

            }

        }

        public bool DeleteUser(string emailId)
        {
            throw new NotImplementedException();
        }

        public string GenerateOTP(string emailId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public User GetUser(string email)
        {
            throw new NotImplementedException();
        }

        public User GetUserByEmail(string emailToMatch)
        {
            throw new NotImplementedException();
        }

        public User GetUserByMobileNo(string mobileNo)
        {
            throw new NotImplementedException();
        }

        public bool LockUser(string email)
        {
            throw new NotImplementedException();
        }

        public bool ResetPassword(string email, string otp, string newPassword)
        {
            throw new NotImplementedException();
        }

        public bool UnlockUser(string email)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public bool ValidateUser(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
