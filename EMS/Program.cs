using RepositoryLib;

namespace EMS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IMembershipRepository mbr = new MembershipRepository();
            mbr.ChangePassword("user1@example.com", "u1new", "User1new");
            
        }
    }
}
