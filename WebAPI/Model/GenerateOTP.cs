using System.ComponentModel.DataAnnotations;

namespace WebAPI.Model
{
    public class GenerateOTP
    {
       

        [Required]
        [EmailAddress]
        public string EmailId { get; set; }
    }
}
