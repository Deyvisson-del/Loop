using Loop.Domain.Entities;

namespace Loop.Application.UseCase.Administrador
{
    public class BuscarListaGestorUseCase
    {
        private readonly IAdministradorRepository _administradorRepository;
        public BuscarListaGestorUseCase(IAdministradorRepository administradorRepository)
        {
            _administradorRepository = administradorRepository;
        }
        public IEnumerable<Loop.Domain.Entities.Gestor> Executar()
        {
            return _administradorRepository.BuscarListaGestor();
        }
    }
}