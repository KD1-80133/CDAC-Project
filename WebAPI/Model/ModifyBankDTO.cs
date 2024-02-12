namespace WebAPI.Model
{
    public class ModifyBankDTO
    {
        public string AccountHolderName { get; set; }
        public string AccountType { get; set; }

        public int UserId { get; set; }

        public override string ToString()
        {
            return this.AccountHolderName + " " + this.AccountType + " " + this.UserId;
        }

    }
}
