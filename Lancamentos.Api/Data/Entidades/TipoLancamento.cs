﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lancamentos.Api.Data.Entidades
{
    [Table("TiposLancamentos")]
    public class TipoLancamento
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(60)]
        public string Descricao { get; set; }
        [Column("Despesa")]
        public bool isDespesas { get; set; } = true;
        public string? ClassIcone { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Ativo { get; set; }
    }
}
