using Loop.Domain.Entities;

namespace Loop.Application.UseCase.Administrador
{
    public class BuscarListaEstagiarioADM
    {
        private readonly IAdministradorRepository _administradorRepository;
        public BuscarListaEstagiarioADM(IAdministradorRepository administradorRepository)
        {
            _administradorRepository = administradorRepository;
        }
        public IEnumerable<Domain.Entities.Estagiario> Executar()
        {
            return _administradorRepository.BuscarListaEstagiario();
        }
    }
}