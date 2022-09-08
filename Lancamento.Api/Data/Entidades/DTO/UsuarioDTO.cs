using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lancamentos.Api.Data.Entidades.DTO
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Sobrenome { get; set; }
        public string? Email { get; set; }
        public string Login { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? Celular { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Ativo { get; set; }
    }
}
