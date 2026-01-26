using Loop.Domain.Entities;

namespace Loop.Application.UseCase.Administrador
{
    public class BuscarEstagiarioIdUseCase
    {
        private readonly IAdministradorRepository _administradorRepository;
        public BuscarEstagiarioIdUseCase(IAdministradorRepository administradorRepository)
        {
            _administradorRepository = administradorRepository;
        }
        public Estagiario? ExecutarPorId(int id)
        {
            return _administradorRepository.BuscarEstagiarioId(id);
        }
    }
}