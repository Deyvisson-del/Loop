using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Loop.Infra.Data.Context
{
    public class LoopDbContextFactory : IDesignTimeDbContextFactory<LoopDbContext>
    {
        public LoopDbContext CreateDbContext(string[] args)
        {
            var connerctionString = "server=localhost;Port=3306;user=root;Password=root;database=Banco_Loop;";

            var optionsBuilder = new DbContextOptionsBuilder<LoopDbContext>();


            optionsBuilder.UseMySql(
                connerctionString,ServerVersion.AutoDetect(connerctionString));
            return new LoopDbContext(optionsBuilder.Options);

        }


    }
}
