using System.ComponentModel.DataAnnotations;

namespace Lancamentos.Api.Data.Entidades.DTO
{
    public class LancamentoDTO
    {
        public int Id { get; set; }
        [Required]
        public int UsuarioId { get; set; }
        public virtual UsuarioDTO Usuario { get; set; }
        [Required]
        public int TipoLancamentoId { get; set; }        
        public virtual TipoLancamentoDTO  TipoLancamento { get; set; }
        [Required]
        public DateTime Data { get; set; }
        [Required]
        [MaxLength(60)]
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public bool IsLancamentoRecorrente { get; set; } = false;
        public DateTime DataCriacao { get; set; }
        public bool Ativo { get; set; }
    }
}
