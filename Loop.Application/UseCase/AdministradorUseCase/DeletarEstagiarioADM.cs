using Loop.Domain.Entities;

namespace Loop.Application.UseCase.Administrador
{
    public class DeletarEstagiarioADM
    {
        private readonly IAdministradorRepository _administradorRepository;
        public DeletarEstagiarioADM(IAdministradorRepository administradorRepository)
        {
            _administradorRepository = administradorRepository;
        }
        public void Execute(int id)
        {
            _administradorRepository.DeletarEstagiario(id);
        }
    }
}