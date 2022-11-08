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
        public DbSet<Lancamento> Lancamentos { get; set; }
        public DbSet<TipoConta> TiposContas { get; set; }
        public DbSet<Conta> Contas { get; set; }
    }
}
