namespace WebAPI.Model.BANKDTO
{
    public class ModifyBankDTO
    {
        public string AccountHolderName { get; set; }
        public string AccountType { get; set; }

        public int UserId { get; set; }

        public override string ToString()
        {
            return AccountHolderName + " " + AccountType + " " + UserId;
        }
    }
}
