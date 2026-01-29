using Loop.Domain.Entities;

namespace Loop.Application.UseCase.Administrador
{
    public class BuscarListaGestorADM
    {
        private readonly IAdministradorRepository _administradorRepository;
        public BuscarListaGestorADM(IAdministradorRepository administradorRepository)
        {
            _administradorRepository = administradorRepository;
        }
        public IEnumerable<Domain.Entities.Gestor> Executar()
        {
            return _administradorRepository.BuscarListaGestor();
        }
    }
}