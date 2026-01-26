using Loop.Domain.Entities;

namespace Loop.Application.UseCase.Administrador
{
    public class BuscarListaEstagiarioUseCase
    {
        private readonly IAdministradorRepository _administradorRepository;
        public BuscarListaEstagiarioUseCase(IAdministradorRepository administradorRepository)
        {
            _administradorRepository = administradorRepository;
        }
        public IEnumerable<Estagiario> Executar()
        {
            return _administradorRepository.BuscarListaEstagiario();
        }
    }
}