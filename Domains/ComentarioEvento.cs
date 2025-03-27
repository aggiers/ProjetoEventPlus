using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Event_Plus.Domains
{
    [Table("ComentarioEvento")]
    public class ComentarioEvento
    {
        [Key]
        public Guid IdComentarioEvento { get; set; }

        [Column(TypeName = "VARCHAR(200)")]
        [Required(ErrorMessage = "A descrição do evento é ")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "Defina se o comentário poderá ser exibido ou não!")]
        public bool Exibe { get; set; }

        public Guid? IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public Usuario? Usuarios { get; set; }

        public Guid? IdEvento { get; set; }
        [ForeignKey("IdEvento")]
        public Evento? Eventos { get; set; }
    }
}
