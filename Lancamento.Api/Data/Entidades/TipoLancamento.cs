using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lancamento.Api.Data.Entidades
{
    [Table("TiposLancamentos")]
    public class TipoLancamento
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(60)]
        public string Descricao { get; set; }
        [Column("Despesa")]
        public bool isDespesas { get; set; } = true;
        public DateTime DataCriacao { get; set; }
        public bool Ativo { get; set; }
    }
}
