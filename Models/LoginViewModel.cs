using System.ComponentModel.DataAnnotations;

namespace MvcWebProje.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username is required."), StringLength(30, ErrorMessage = "Username can be max 30 characters.")]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
