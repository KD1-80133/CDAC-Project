using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnitityModelLib
{
    [Table("T_BankAccount")]
    public class BankAccount
    {
        [Key]
        [Required]
        [Column("AccountNo")]
        public int AccountNo { get; set; }
        [Required]
        [Column("AccountHolderName")]
        public string AccountHolderName { get; set; }
        [Required]
        [Column("AccountType")]
        public string AccountType { get; set; }
        [Required]
        [Column("BankName")]
        public string BankName { get; set; }
        [Required]
        [Column("IFSCCode")]
        public int IFSCCode { get; set; }
        [Required]
        [Column("UserId")]
        public int UserId { get; set; }

        public override string ToString()
        {
            return $"AccountNo: {AccountNo}, AccountHolderName: {AccountHolderName}, AccountType: {AccountType}, BankName: {BankName}, IFSCCode: {IFSCCode}, UserId: {UserId}";
        }
    }
}
