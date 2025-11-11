using Loop.Domain.Interfaces;
using Loop.Infra.Data.Context;
using Loop.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Loop.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // 🔧 Adiciona o DbContext
            services.AddDbContext<LoopDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddScoped<IFrequenciaRepository, FrequenciaRepository>();
            services.AddScoped<IEstagiarioRepository, EstagiarioRepository>();
            services.AddScoped<IGestorRepository, GestorRepository>();

            // (Depois, quando criarmos a camada Application)
            // services.AddScoped<IFrequenciaService, FrequenciaService>();

            return services;
        }
    }
}
