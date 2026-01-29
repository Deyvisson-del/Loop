using Loop.Domain.Entities;

namespace Loop.Application.UseCase.Administrador
{
    public class BuscarEstagiarioNomeADM
    {
        private readonly IAdministradorRepository _administradorRepository;
        public BuscarEstagiarioNomeADM(IAdministradorRepository administradorRepository)
        {
            _administradorRepository = administradorRepository;
        }
        public IEnumerable<Domain.Entities.Estagiario> Execute(string nomeBusca)
        {
            return _administradorRepository.BuscarEstagiarioNome(nomeBusca);
        }
    }
}