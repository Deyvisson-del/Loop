using Loop.Domain.Interfaces;
using Loop.Infra.Data.Context;
using Loop.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Loop.Infra.Data
{
    public static class DependencyInjection
    {
       public static void AddDataInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Register DbContext
            services.AddDbContext<LoopDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            // Register Repositories
            services.AddScoped<IFrequenciaRepository, FrequenciaRepository>();
            services.AddScoped<IEstagiarioRepository, EstagiarioRepository>();
            services.AddScoped<IGestorRepository, GestorRepository>();

            
        }
    }
}
