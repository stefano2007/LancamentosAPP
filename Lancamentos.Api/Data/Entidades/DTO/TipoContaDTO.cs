using System.ComponentModel.DataAnnotations;

namespace Lancamentos.Api.Data.Entidades.DTO
{
    public class TipoContaDTO
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string? ClassIcone { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Ativo { get; set; }
    }
}
