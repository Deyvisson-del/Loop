using Loop.Domain.Entities;

namespace Loop.Application.UseCase.Administrador
{
    public class DeletarGestorADM
    {
        private readonly IAdministradorRepository _administradorRepository;
        public DeletarGestorADM(IAdministradorRepository administradorRepository)
        {
            _administradorRepository = administradorRepository;
        }
        public void Executar(int id)
        {
            _administradorRepository.DeletarGestor(id);
        }
    }
}