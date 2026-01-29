using Loop.Domain.Entities;

namespace Loop.Application.UseCase.Administrador
{
    public class CriarEstagiarioADM
    {
        private readonly IAdministradorRepository _administradorRepository;
        public CriarEstagiarioADM(IAdministradorRepository administradorRepository)
        {
            _administradorRepository = administradorRepository;
        }
        public void Executar(Domain.Entities.Estagiario estagiario)
        {
            _administradorRepository.CriarEstagiario(estagiario);
        }
    }
}