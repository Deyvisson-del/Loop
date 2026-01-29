using Loop.Domain.Entities;

namespace Loop.Application.UseCase.Administrador
{
    public class BuscarGestorNomeADM
    {
        private readonly IAdministradorRepository _administradorRepository;
        public BuscarGestorNomeADM(IAdministradorRepository administradorRepository)
        {
            _administradorRepository = administradorRepository;
        }
        public IEnumerable<Domain.Entities.Gestor> Executar(string nome)
        {
            return _administradorRepository.BuscarGestorNome(nome);
        }
    }
}