namespace EnitityModelLib
{
    public class User
    {
        public int UserId { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }

        public string MobileNo { get; set; }
        public bool IsOnline { get; set; }

        public bool IsLocked { get; set; }
        public int RoleId { get; set; }
        public string Name { get; set; }

        public string AdharNumber { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return $"UserId: {0}, EmailId: {1}, Password: {2}, MobileNo: {3}, IsOnline: {4}, IsLocked: {5}, RoleId: {6}, Name: {7}, AdharNumber: {8}, Address: {9}";
        }



    }
}
