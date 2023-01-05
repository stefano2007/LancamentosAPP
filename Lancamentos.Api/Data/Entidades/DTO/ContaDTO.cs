using System.ComponentModel.DataAnnotations;

namespace Lancamentos.Api.Data.Entidades.DTO
{
    public class ContaDTO
    {
        public int Id { get; set; }
        public int ContaId { get; set; }
        public int TipoContaId { get; set; }
        public TipoConta TipoConta { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public string Nome { get; set; }
        public int? DiaFechamentoFatura { get; set; }
        public int? DiaVencimentoFatura { get; set; }
        public decimal SaldoAtual { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public bool Ativo { get; set; } = true;
    }
}
