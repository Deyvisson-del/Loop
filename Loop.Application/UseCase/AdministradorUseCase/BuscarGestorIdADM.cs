using Loop.Domain.Entities;

namespace Loop.Application.UseCase.Administrador
{
    public class BuscarGestorIdADM
    {
        private readonly IAdministradorRepository _administradorRepository;
        public BuscarGestorIdADM(IAdministradorRepository administradorRepository)
        {
            _administradorRepository = administradorRepository;
        }
        public Domain.Entities.Gestor? Executar(int id)
        {
            return _administradorRepository.BuscarGestorId(id);
        }
    }
}