using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lancamentos.Api.Data.Entidades.DTO
{
    public class TipoLancamentoInsertDTO
    {
        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [MaxLength(60)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatória.")]
        public bool isDespesas { get; set; } = true;
    }
}