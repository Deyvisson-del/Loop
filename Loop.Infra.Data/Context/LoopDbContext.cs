using Microsoft.EntityFrameworkCore;
using Loop.Domain.Entities;

namespace Loop.Infra.Data.Context
{
    public class LoopDbContext : DbContext
    {
        public LoopDbContext(DbContextOptions<LoopDbContext> options) : base(options) { }

        public DbSet<Estagiario> Estagiarios { get; set; }
        public DbSet<Frequencia> Frequencias { get; set; }
        public DbSet<Gestor> Gestores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LoopDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
