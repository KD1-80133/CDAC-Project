using EntityModel;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLib
{
    public class RoleRepository : IRoleRepository
    {
        private static String? _ConnectionDetails = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Logger;Integrated Security=True;Encrypt=True";

        public static String? ConnectionDetails
        {
            get { return _ConnectionDetails; }
            set { _ConnectionDetails = value; }
        }
        public bool CreateRole(string roleName)
        {
            SqlConnection connection = new SqlConnection(_ConnectionDetails);
            connection.Open();

            SqlCommand command = new SqlCommand("spInsertRoleName", connection);

            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@RoleName", roleName);
            int RowsAffected = command.ExecuteNonQuery();
            if (RowsAffected == 1)
                return true;
            else
                return false;
        }

        public bool DeleteRole(string roleId)
        {
            SqlConnection connection = new SqlConnection(_ConnectionDetails);
            connection.Open();
            SqlCommand command = new SqlCommand("spRemoveRoleNameByRoleId", connection);

            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@RoleId", roleId);

            int rowsaffected = command.ExecuteNonQuery();

            connection.Close();

            if (rowsaffected == 1)
                return true;
            else
                return false;
        }

        public List<Role> GetAllRoles()
        {
            SqlConnection connection = new SqlConnection(_ConnectionDetails);
            connection.Open();

            SqlCommand command = new SqlCommand("select * from T_Roles", connection);

            SqlDataReader reader = command.ExecuteReader();

            List<Role> ListOfRoles = new List<Role>();

            while (reader.Read())
            {
                Role role = new Role();
                role.RoleId = Convert.ToInt32(reader["RoleId"]);
                role.RoleName = reader["RoleName"].ToString();
                ListOfRoles.Add(role);
            }
            return ListOfRoles;

        }

        public bool IsUserInRole(string userName, string roleName)
        {
            SqlConnection connection = new SqlConnection(_ConnectionDetails);
            connection.Open();

            //SqlCommand command = new SqlCommand("select count(UserId) from T_User where Name = @UserName and RoleId = (select RoleId from T_Roles where RoleName = @RoleName)", connection);
            string query = "select count(u.UserId) from T_User u,T_Roles r where r.RoleId = u.RoleId and u.Name = @UserName and r.RoleName = @RoleName";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", userName);
            command.Parameters.AddWithValue("@RoleName", roleName);


            int count = (int)command.ExecuteScalar();
            if (count > 0)
                return true;
            else
                return false;
        }
    }
}
