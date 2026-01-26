using Loop.Domain.Entities;

namespace Loop.Application.UseCase.Administrador
{
    public class BuscarEstagiarioNomeUseCase
    {
        private readonly IAdministradorRepository _administradorRepository;
        public BuscarEstagiarioNomeUseCase(IAdministradorRepository administradorRepository)
        {
            _administradorRepository = administradorRepository;
        }
        public IEnumerable<Estagiario> Execute(string nomeBusca)
        {
            return _administradorRepository.BuscarEstagiarioNome(nomeBusca);
        }
    }
}