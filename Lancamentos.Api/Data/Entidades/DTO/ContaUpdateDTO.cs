using System.ComponentModel.DataAnnotations;

namespace Lancamentos.Api.Data.Entidades.DTO
{
    public class ContaUpdateDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(60)]
        public string Nome { get; set; }
        public int? DiaFechamentoFatura { get; set; }
        public int? DiaVencimentoFatura { get; set; }
        public decimal SaldoAtual { get; set; }
    }
}
