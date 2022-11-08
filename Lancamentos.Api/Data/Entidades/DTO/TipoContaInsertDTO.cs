using System.ComponentModel.DataAnnotations;

namespace Lancamentos.Api.Data.Entidades.DTO
{
    public class TipoContaInsertDTO
    {
        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [MaxLength(60)]
        public string Descricao { get; set; }

        public string ClassIcone { get; set; }
    }
}
