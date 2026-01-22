using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Loop.Infra.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<Contexto>
    {
        public Contexto CreateDbContext(string[] args)
        {
            var conectionString = "server=localhost;Port=3306;user=root;password=root;database=Banco_Loop;";
            var optionBuilder = new DbContextOptionsBuilder<Contexto>();

            optionBuilder.UseMySql(conectionString, ServerVersion.AutoDetect(conectionString));
            return new Contexto(optionBuilder.Options);
        }
    }
}