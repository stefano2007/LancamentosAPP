using System.ComponentModel.DataAnnotations;

namespace Lancamentos.Api.Data.Entidades.DTO
{
    public class TipoContaUpdateDTO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(60)]
        public string Descricao { get; set; }

        public string ClassIcone { get; set; }
    }
}
