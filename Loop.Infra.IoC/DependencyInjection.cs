using Loop.Infra.Data.Context;
using Loop.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Loop.Domain.Entities;
using Loop.Application.Services;

namespace Loop.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<Contexto>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
            services.AddScoped<IAdministradorRepository, AdministradorRepository>();
            services.AddScoped<IEstagiarioRepository, EstagiarioRepository>();
            services.AddScoped<IGestorRepository, GestorRepository>();
            services.AddScoped<AdministradorService>();
            services.AddScoped<EstagiarioService>();
            services.AddScoped<GestorService>();

            return services;
        }
    }
}