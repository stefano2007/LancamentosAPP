using Lancamento.Api.Data.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Lancamento.Api.Data
{
    public class LancamentoContext : DbContext
    {
        public LancamentoContext(DbContextOptions<LancamentoContext> options) : base(options)
        {

        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<TipoLancamento> TiposLancamentos { get; set; }
        public DbSet<ItemLancamento> Lancamentos { get; set; }
    }
}
