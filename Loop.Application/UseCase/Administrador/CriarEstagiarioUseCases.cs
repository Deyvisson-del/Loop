using Loop.Domain.Entities;

namespace Loop.Application.UseCase.Administrador
{
    public class CriarEstagiarioUseCases
    {
        private readonly IAdministradorRepository _administradorRepository;

        public CriarEstagiarioUseCases(IAdministradorRepository administradorRepository)
        {
            _administradorRepository = administradorRepository;
        }

        public void Executar(Estagiario estagiario)
        {
            _administradorRepository.CriarEstagiario(estagiario);
        }
    }
}