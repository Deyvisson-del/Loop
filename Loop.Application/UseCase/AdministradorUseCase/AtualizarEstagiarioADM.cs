using Loop.Domain.Entities;

namespace Loop.Application.UseCase.EstagiarioUseCase
{
    public class AtualizarEstagiarioADM
    {
        private readonly IAdministradorRepository _administradorRepository;
        public AtualizarEstagiarioADM(IAdministradorRepository administradorRepository)
        {
            _administradorRepository = administradorRepository;
        }
        public void Executar(Domain.Entities.Estagiario estagiario)
        {
            _administradorRepository.AtualizarEstagiario(estagiario);
        }
    }
}