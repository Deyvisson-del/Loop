using Loop.Domain.Entities;

namespace Loop.Application.UseCase.Administrador
{
    public class CriarEstagiarioUseCase
    {
        private readonly IAdministradorRepository _administradorRepository;

        public CriarEstagiarioUseCase(IAdministradorRepository administradorRepository)
        {
            _administradorRepository = administradorRepository;
        }

        public void Executar(Estagiario estagiario)
        {
            _administradorRepository.CriarEstagiario(estagiario);
        }
    }
}