using System.ComponentModel.DataAnnotations;

namespace Lancamentos.Api.Data.Entidades.DTO
{
    public class LancamentoUpdateDTO
    {
        public int Id { get; set; }
        [Required]
        public int TipoLancamentoId { get; set; }
        [Required]
        public DateTime Data { get; set; }
        [Required]
        [MaxLength(60)]
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public bool IsLancamentoRecorrente { get; set; } = false;
        public bool Ativo { get; set; }
    }
}
