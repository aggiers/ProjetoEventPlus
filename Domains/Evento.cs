using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Event_Plus.Domains
{
    [Table("Evento")]
    public class Evento
    {
        [Key]
        public Guid IdEvento { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O nome do evento é obrigatório!")]
        public string? NomeEvento { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "A data do evento é obrigatório!")]
        public DateTime? DataEvento { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "A data do evento é obrigatório!")]
        public string? Descricao { get; set; }

        /// <summary>
        /// Rerencia as demais tabelas
        /// </summary>
        public Guid IdTipoEvento { get; set; }
        [ForeignKey("IdTipoEvento")]
        public TipoEvento? TiposEvento { get; set; }

        public Guid IdInstituicao { get; set; }
        [ForeignKey("IdInstituicao")]
        public Instituicao? Instituicao { set; get; }

        public PresencaEvento? PresencaEventos { get; set; }


    }
}
