using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lancamentos.Api.Data.Entidades
{
    [Table("Lancamentos")]
    public class Lancamento
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        [Required]
        public int TipoLancamentoId { get; set; }        
        public virtual TipoLancamento  TipoLancamento { get; set; }
        [Required]
        [Column("DataLancamento")]
        public DateTime Data { get; set; }
        [Required]
        [MaxLength(60)]
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        [Column("LancamentoRecorrente")]
        public bool IsLancamentoRecorrente { get; set; } = false;
        public DateTime DataCriacao { get; set; }
        public bool Ativo { get; set; }
    }
}
