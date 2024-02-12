namespace WebAPI.Model
{
    public class ModifyEmpDTO
    {
        /*public int EmpId { get; set; }*/
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int DesignationId { get; set; }

       
        public int HourlyRate { get; set; }
        public bool IsResigned { get; set; }
        public int DeptId { get; set; }

        public int ManagerId { get; set; }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName + " " + this.DesignationId + " "  + this.HourlyRate
                + " " + this.IsResigned + " " + this.DeptId + " " + this.ManagerId;
        }
    }
}

