using EnitityModelLib;

namespace RepositoryLib
{
    public interface IMembershipRepository
    {
        public bool LockUser(string email);
        public bool UnlockUser(string email);
        public bool ValidateUser(string email, string password);
        public bool CreateUser(string userName, string password, string mobileNo, string emailId);
        public bool ChangePassword(string email, string oldPassword, string newPassword);
        public int GetNumberOfUsersOnline();
        public bool UpdateUser(User user);
        public IEnumerable<User> GetAllUsers();
        public User GetUser(string email);
        User GetUserByEmail(string emailToMatch);
        User GetUserByMobileNo(string mobileNo);
        string GenerateOTP(string emailId);
        bool ResetPassword(string email, string otp, string newPassword);
        bool DeleteUser(string emailId);
    }
}
