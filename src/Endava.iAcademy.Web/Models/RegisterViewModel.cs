using System.ComponentModel.DataAnnotations;

namespace Endava.iAcademy.Web.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email not specified")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password not specified")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password entered incorrectly")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Role not specified")]
        public string Role { get; set; }
    }
}
