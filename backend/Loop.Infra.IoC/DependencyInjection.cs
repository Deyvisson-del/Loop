using Mapster;
using MapsterMapper;
using Loop.Application.Interfaces;
using Loop.Application.Services;
using Loop.Domain.Interfaces;
using Loop.Infra.Data.Context;
using Loop.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.DependencyInjection;

namespace Loop.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<LoopDbContext>(options =>
                          options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            services.AddScoped<IEstagiarioRepository, EstagiarioRepository>();
            services.AddScoped<IGestorRepository, GestorRepository>();
            services.AddScoped<IAdministradorRepository, AdministradorRepository>();
            services.AddScoped<ISolicitacaoRepository, SolicitacaoRepository>();
            services.AddScoped<IFrequenciaRepository, FrequenciaRepository>(); ;

            var config = TypeAdapterConfig.GlobalSettings;
            services.AddSingleton(config);
            services.AddScoped<IMapper, Mapper>();

            services.AddScoped<IEstagiarioService, EstagiarioService>();
            services.AddScoped<IFrequenciaService, FrequenciaService>();
            services.AddScoped<IAdministradorService, AdministradorService>();
            services.AddScoped<ISolicitacaoService>, SolicitacaoService>();

            return services;
        }
    }
}
