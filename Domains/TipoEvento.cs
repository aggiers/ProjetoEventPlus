using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Event_Plus.Domains
{
    [Table("TipoEvento")]
    public class TipoEvento
    {
        [Key]
        public Guid IdTipoEvento { get; set; }

        [Column(TypeName = "VARCHAR(60)")]
        [Required(ErrorMessage = "O tipo do evento é ")]
        public string? TituloTipoEvento { get; set; }
    }
}
