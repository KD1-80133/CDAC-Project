using System.ComponentModel.DataAnnotations;

namespace WebAPI.Model
{
    public class ChangePassword
    {
        [Required]
        [EmailAddress]
        public string EmailId { get; set; }

        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
