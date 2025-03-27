using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Projeto_Event_Plus.Domains
{
    [Table("Instituicao")]
    [Index(nameof(CNPJ), IsUnique = true)]
    public class Instituicao
    {
        [Key]
        public Guid IdInstituicao { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O nome fantasia é ")]
        public string? NomeFantasia { get; set; }

        [Column(TypeName = "VARCHAR(120)")]
        [Required(ErrorMessage = "O endereço é ")]
        public string? Endereco { get; set; }

        [Column(TypeName = "VARCHAR(14)")]
        [Required(ErrorMessage = "O CNPJ é obrigatório!")]
        [StringLength(14)]
        public string? CNPJ { get; set; }
    }
}
