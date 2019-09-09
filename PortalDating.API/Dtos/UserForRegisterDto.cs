using System.ComponentModel.DataAnnotations;

namespace PortalDating.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required(ErrorMessage = "Nazwa użytkownika jest wymagana.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Hasło jest wymagane")]
        [StringLength(12, MinimumLength = 4, ErrorMessage = "Hasło musi posiadać 4 do 8 znaków.")]
        public string Password { get; set; }
    }
}