using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lancamentos.Api.Data.Entidades
{
    [Table("TiposContas")]
    public class TipoConta
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(60)]
        public string Descricao { get; set; }
        public string? ClassIcone { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Ativo { get; set; }
    }
}
