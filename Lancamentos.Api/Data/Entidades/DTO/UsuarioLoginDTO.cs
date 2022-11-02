namespace Lancamentos.Api.Data.Entidades.DTO
{
    public class UsuarioLoginDTO
    {
        public string Email { get; set; }        
        public string Login { get; set; }
        public string Nome { get; set; }
        public int UsuarioId { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; }
    }
}
