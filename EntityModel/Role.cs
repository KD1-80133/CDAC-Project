namespace EntityModel
{
    public class Role
    {
        public int RoleId { get; set;}
        public string RoleName { get; set; }


        public override string ToString()
        {
            return this.RoleId + " " + this.RoleName ;
        }


    }
}
