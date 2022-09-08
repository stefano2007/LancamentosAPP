using Lancamentos.Api.Data.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Lancamentos.Api.Data
{
    public class LancamentoContext : DbContext
    {
        public LancamentoContext(DbContextOptions<LancamentoContext> options) : base(options) { 
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<TipoLancamento> TiposLancamentos { get; set; }
        public DbSet<Entidades.Lancamento> Lancamentos { get; set; }
    }
}
