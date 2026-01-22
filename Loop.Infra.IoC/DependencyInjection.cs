using Loop.Infra.Data.Context;
using Loop.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Loop.Application.UseCase.Administrador;
using Loop.Domain.Entities;

namespace Loop.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructure(this  IServiceCollection services, string connectionString)
        {
            services.AddDbContext<Contexto>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            services.AddScoped<IAdministradorRepository, AdministradorRepository>();
            services.AddScoped<IEstagiarioRepository, EstagiarioRepository>();


            services.AddScoped<CriarEstagiarioUseCases>();
            return services;
        }
    }
}
