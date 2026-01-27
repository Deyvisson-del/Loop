using Loop.Domain.Entities;

namespace Loop.Application.UseCase.Administrador
{
    public class CriarGestorADM
    {
        private readonly IAdministradorRepository _administradorRepository;
        public CriarGestorADM(IAdministradorRepository administradorRepository)
        {
            _administradorRepository = administradorRepository;
        }
        public void Executar(Domain.Entities.Gestor gestor)
        {
            _administradorRepository.CriarGestor(gestor);
        }
    }
}