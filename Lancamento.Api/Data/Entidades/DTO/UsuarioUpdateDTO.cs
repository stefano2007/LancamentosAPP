using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lancamentos.Api.Data.Entidades.DTO
{
    public class UsuarioUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(60)]
        public string Nome { get; set; }
        [MaxLength(60)]
        public string? Sobrenome { get; set; }
        [MaxLength(120)]
        public string? Email { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? Celular { get; set; }
    }
}
