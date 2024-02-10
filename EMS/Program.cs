using RepositoryLib;

namespace EMS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IMembershipRepository mbr = new MembershipRepository();
            Console.WriteLine(
            mbr.ValidateUser("user1@example.com","nopassword"));
            
        }
    }
}
