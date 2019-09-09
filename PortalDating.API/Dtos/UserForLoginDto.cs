using System.ComponentModel.DataAnnotations;

namespace PortalDating.API.Dtos
{
    public class UserForLoginDto
    {
        [Required(ErrorMessage = "Nazwa użytkownika jest wymagana!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Hasło jest wymagane!")]
        public string Password { get; set; }
    }
}