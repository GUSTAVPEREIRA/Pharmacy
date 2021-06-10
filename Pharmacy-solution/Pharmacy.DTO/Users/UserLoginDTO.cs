using System.ComponentModel.DataAnnotations;

namespace Pharmacy.DTO.Users
{
    public class UserLoginDTO
    {
        [Required(ErrorMessage = "O campo username é um campo obrigatório!")]
        [StringLength(maximumLength: 30, MinimumLength = 5, ErrorMessage = "O username deverá conter de 5 a 30 caracteres!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "O campo senha é um campo obrigatório!")]
        [StringLength(maximumLength: 20, MinimumLength = 6, ErrorMessage = "A senha deverá conter de 6 a 20 caracteres!")]
        public string Password { get; set; }
    }
}
