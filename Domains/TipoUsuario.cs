using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Event_Plus.Domains
{
    [Table("TipoUsuario")]
    public class TipoUsuario
    {
        [Key]
        public Guid IdTipoUsuario { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "O titulo de usuario é ")]
        public string? TituloTipoUsuario { get; set; }
    }
}
