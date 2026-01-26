using Microsoft.EntityFrameworkCore;
using Loop.Domain.Entities;
using Loop.Domain.Requests;

namespace Loop.Infra.Data.Context
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Estagiario> Estagiarios { get; set; }
        public DbSet<Gestor> Gestores { get; set; }
        public DbSet<Frequencia> Frequencias { get; set; }
        public DbSet<Solicitacao> Solicitacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Contexto).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}