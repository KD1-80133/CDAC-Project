namespace WebAPI.Model.PROJMEMBDTO
{
    public class AddProjMembDTO
    {
        public int UserId { get; set; }
        public int ProjectId { get; set; }

        public override string ToString()
        {
            return UserId + " " + ProjectId;
        }
    }
}
