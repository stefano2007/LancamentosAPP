using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lancamento.Api.Data.Entidades.DTO
{
    public class TipoLancamentoUpdateDTO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(60)]
        public string Descricao { get; set; }
        [Required]
        public bool isDespesas { get; set; } = true;
    }
}