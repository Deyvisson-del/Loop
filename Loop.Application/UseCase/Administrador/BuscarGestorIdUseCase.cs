using Loop.Domain.Entities;

namespace Loop.Application.UseCase.Administrador
{
    public class BuscarGestorIdUseCase
    {
        private readonly IAdministradorRepository _administradorRepository;
        public BuscarGestorIdUseCase(IAdministradorRepository administradorRepository)
        {
            _administradorRepository = administradorRepository;
        }
        public Loop.Domain.Entities.Gestor? Executar(int id)
        {
            return _administradorRepository.BuscarGestorId(id);
        }
    }
}