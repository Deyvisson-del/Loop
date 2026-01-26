using Loop.Domain.Entities;

namespace Loop.Application.UseCase.Administrador
{
    public class AtualizarEstagiarioUseCase
    {
        private readonly IAdministradorRepository _administradorRepository;
        public AtualizarEstagiarioUseCase(IAdministradorRepository administradorRepository)
        {
            _administradorRepository = administradorRepository;
        }
        public void Executar(Estagiario estagiario)
        {
            _administradorRepository.AtualizarEstagiario(estagiario);
        }
    }
}