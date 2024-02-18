namespace WebAPI.Model.PROJMEMBDTO
{
    public class ProjMembDTO
    {
        public int ProjMemberId { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }

        public override string ToString()
        {
            return ProjMemberId + " " + UserId + " " + ProjectId;
        }
    }
}
