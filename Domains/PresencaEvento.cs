using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Event_Plus.Domains
{
    [Table("PresencaEvento")]
    public class PresencaEvento
    {
        [Key]
        public Guid IdPresencaEvento { get; set; }

        public bool Situacao { get; set; }

        public Guid IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public Usuario? Usuarios { get; set; }

        public Guid IdEvento { get; set; }
        [ForeignKey("IdEvento")]
        public Evento? Eventos { get; set; }
    }
}
