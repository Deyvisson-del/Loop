using Loop.Domain.Entities;

namespace Loop.Application.UseCase.Administrador
{
    public class BuscarGestorNomeUseCase
    {
        private readonly IAdministradorRepository _administradorRepository;
        public BuscarGestorNomeUseCase(IAdministradorRepository administradorRepository)
        {
            _administradorRepository = administradorRepository;
        }
        public IEnumerable<Loop.Domain.Entities.Gestor> Executar(string nome)
        {
            return _administradorRepository.BuscarGestorNome(nome);
        }
    }
}