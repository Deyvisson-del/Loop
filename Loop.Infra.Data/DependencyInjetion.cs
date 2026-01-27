using Loop.Domain.Entities;
using Loop.Infra.Data.Context;
using Loop.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Loop.Infra.Data
{
    public static class DependencyInjetion
    {
        public static void AddDataInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<Contexto>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
            services.AddScoped<IEstagiarioRepository, EstagiarioRepository>();
            services.AddScoped<IAdministradorRepository, AdministradorRepository>();


        }
    }
}