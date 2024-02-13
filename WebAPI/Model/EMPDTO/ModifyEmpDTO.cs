namespace WebAPI.Model.EMPDTO
{
    public class ModifyEmpDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int DesignationId { get; set; }


        public int HourlyRate { get; set; }
        public bool IsResigned { get; set; }
        public int DeptId { get; set; }

        public int ManagerId { get; set; }
        public int UserId { get; set; }

        public override string ToString()
        {
            return FirstName + " " + LastName + " " + DesignationId + " " + HourlyRate
                + " " + IsResigned + " " + DeptId + " " + ManagerId + " " + UserId;
        }
    }
}
