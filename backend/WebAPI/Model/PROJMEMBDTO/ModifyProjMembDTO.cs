namespace WebAPI.Model.PROJMEMBDTO
{
    public class ModifyProjMembDTO
    {
        public int UserId { get; set; }
        public int ProjectId { get; set; }

        public override string ToString()
        {
            return UserId + " " + ProjectId;
        }
    }
}
