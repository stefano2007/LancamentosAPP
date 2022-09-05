using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lancamento.Api.Data.Entidades.DTO
{
    public class TipoLancamentoInsertDTO
    {
        [Required]
        [MaxLength(60)]
        public string Descricao { get; set; }
        [Column("Despesa")]
        public bool isDespesas { get; set; } = true;
    }
}