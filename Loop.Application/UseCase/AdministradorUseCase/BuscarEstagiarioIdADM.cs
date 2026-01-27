using Loop.Domain.Entities;

namespace Loop.Application.UseCase.Administrador
{
    public class BuscarEstagiarioIdADM
    {
        private readonly IAdministradorRepository _administradorRepository;
        public BuscarEstagiarioIdADM(IAdministradorRepository administradorRepository)
        {
            _administradorRepository = administradorRepository;
        }
        public Domain.Entities.Estagiario? ExecutarPorId(int id)
        {
            return _administradorRepository.BuscarEstagiarioId(id);
        }
    }
}