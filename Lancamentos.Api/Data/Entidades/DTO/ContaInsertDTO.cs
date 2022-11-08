using System.ComponentModel.DataAnnotations;

namespace Lancamentos.Api.Data.Entidades.DTO
{
    public class ContaInsertDTO
    {
        public int Id { get; set; }
        [Required]
        public int TipoContaId { get; set; }
        [Required]
        public int UsuarioId { get; set; }
        [Required]
        [MaxLength(60)]
        public string Nome { get; set; }
        public int? DiaFechamentoFatura { get; set; }
        public int? DiaVencimentoFatura { get; set; }
        public decimal SaldoAtual { get; set; }
    }
}
