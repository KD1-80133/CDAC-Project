using System.ComponentModel.DataAnnotations;

namespace WebAPI.Model
{
    public class ResetPassword
    {
        [Required]
        [EmailAddress]
        public string EmailId { get; set; }
        [Required]
        public string OTP { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
