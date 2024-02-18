using System.ComponentModel.DataAnnotations;

namespace WebAPI.Model
{
    public class SignUp
    {
        [Required]
        public string userName { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string mobileNo { get; set; }
        [Required]
        [EmailAddress]
        public string emailId { get; set; }
    }
}
