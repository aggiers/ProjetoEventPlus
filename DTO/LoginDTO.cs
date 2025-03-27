using System.ComponentModel.DataAnnotations;

namespace Projeto_Event_Plus.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Informe o E-mail do usuário!")]
        public string? Email { get; set; }


        [Required(ErrorMessage = "A senha é obrigatório")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "Informe a Senha di ")]
        public string? Senha { get; set; }
    }
}
