using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lancamentos.Api.Data.Entidades
{
    [Table("Contas")]
    public class Conta
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int TipoContaId { get; set; }
        public virtual TipoConta TipoConta { get; set; }
        [Required]
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        [Required]
        [MaxLength(60)]
        public string Nome { get; set; }
        public int? DiaFechamentoFatura { get; set; }
        public int? DiaVencimentoFatura { get; set; }
        public decimal SaldoAtual { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public bool Ativo { get; set; } = true;
    }
}
