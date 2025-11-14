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
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<LoopDbContext>(options =>
                          options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            services.AddScoped<IFrequenciaRepository, FrequenciaRepository>();
            services.AddScoped<IEstagiarioRepository, EstagiarioRepository>();
            services.AddScoped<IGestorRepository, GestorRepository>();

            return services;
        }
    }
}
