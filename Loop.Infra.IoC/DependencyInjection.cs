using Loop.Infra.Data.Context;
using Loop.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Loop.Application.UseCase.Administrador;
using Loop.Domain.Entities;
using Loop.Application.UseCase.Gestor;
using Loop.Application.UseCase.EstagiarioUseCase;

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
            services.AddScoped<CriarEstagiarioADM>();
            services.AddScoped<CriarGestorADM>();
            services.AddScoped<AtualizarEstagiarioADM>();
            services.AddScoped<BuscarEstagiarioIdADM>();
            services.AddScoped<BuscarGestorNomeADM>();
            services.AddScoped<BuscarEstagiarioNomeADM>();
            services.AddScoped<BuscarEstagiarioIdADM>();
            services.AddScoped<BuscarGestorIdADM>();
            services.AddScoped<DeletarEstagiarioADM>();
            services.AddScoped<DeletarGestorADM>();
            services.AddScoped<AtualizarEstagiarioGES>();
            services.AddScoped<BuscarIdEstagiarioGES>();
            services.AddScoped<BuscarNomeEstagiarioGES>();
            services.AddScoped<CriarEstagiarioGES>();
            services.AddScoped<DeletarEstagiarioGES>();
            return services;
        }
    }
}