using System.ComponentModel.DataAnnotations;

namespace Dune.Models
{
    public class UserApiModel
    {
        [Required(ErrorMessage = "A username is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "A email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A password is required")]
        public string Password { get; set; }
    }
}
