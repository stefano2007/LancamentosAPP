using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Lancamentos.Api.Data.Entidades
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(60)]
        public string Nome { get; set; }
        [MaxLength(60)]
        public string? Sobrenome { get; set; }
        [Required]
        [MaxLength(120)]
        public string Email { get; set; }
        [Required]
        [Column("dsLogin"), MinLength(3), MaxLength(60)]
        //[Index("INDEX_LOGIN",  IsUnique = true)]
        public string Login { get; set; }
        [Required]
        [Column("PassLogin"), MinLength(6), MaxLength(15)]
        [JsonIgnore]
        public string Senha { get; set; } = "123456";
        public DateTime? DataNascimento { get; set; }
        [MaxLength(11)]
        public string? Celular { get; set; }
        public string? Profissao { get; set; }
        public bool ReceberNoficacoesPorEmail { get; set; } = false;
        public DateTime DataCriacao { get; set; }
        public bool Ativo { get; set; }
    }
}
