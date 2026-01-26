using Loop.Domain.Entities;

namespace Loop.Application.UseCase.Administrador
{
    public class DeletarGestorUseCase
    {
        private readonly IAdministradorRepository _administradorRepository;
        public DeletarGestorUseCase(IAdministradorRepository administradorRepository)
        {
            _administradorRepository = administradorRepository;
        }
        public void Executar(int id)
        {
            _administradorRepository.DeletarGestor(id);
        }
    }
}