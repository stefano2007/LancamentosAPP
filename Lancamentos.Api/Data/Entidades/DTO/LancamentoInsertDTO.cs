using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Lancamentos.Api.Data.Entidades.DTO
{
    public class LancamentoInsertDTO
    {
        [Required]
        public int ContaId { get; set; }
        [Required]
        public int TipoLancamentoId { get; set; }        
        [Required]
        public DateTime Data { get; set; }
        [Required]
        [MaxLength(60)]
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public bool IsLancamentoRecorrente { get; set; } = false;
        [Required]
        public int UsuarioId { get; set; }
    }
}
