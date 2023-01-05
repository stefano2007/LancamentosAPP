using System.ComponentModel.DataAnnotations;

namespace Lancamentos.Api.Data.Entidades
{
    public class UsuarioAlterarSenha
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string SenhaAtual { get; set; }
        [Required]
        public string NovaSenha { get; set; }
    }
}
