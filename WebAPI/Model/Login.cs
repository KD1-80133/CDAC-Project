using System.ComponentModel.DataAnnotations;

namespace WebAPI.Model
{
    public class Login
    {
        [Required]
        [EmailAddress]
        public string EmailId { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
