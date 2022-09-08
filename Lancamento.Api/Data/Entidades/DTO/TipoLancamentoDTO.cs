using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lancamentos.Api.Data.Entidades.DTO
{
    public class TipoLancamentoDTO
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool isDespesas { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Ativo { get; set; }
    }
}