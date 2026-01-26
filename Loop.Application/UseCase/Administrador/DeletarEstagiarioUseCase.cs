using Loop.Domain.Entities;

namespace Loop.Application.UseCase.Administrador
{
    public class DeletarEstagiarioUseCase
    {
        private readonly IAdministradorRepository _administradorRepository;
        public DeletarEstagiarioUseCase(IAdministradorRepository administradorRepository)
        {
            _administradorRepository = administradorRepository;
        }
        public void Execute(int id)
        {
            _administradorRepository.DeletarEstagiario(id);
        }
    }
}