using Loop.Domain.Entities;

namespace Loop.Application.UseCase.Administrador
{
    public class CriarGestorUseCase
    {
        private readonly IAdministradorRepository _administradorRepository;
        public CriarGestorUseCase(IAdministradorRepository administradorRepository)
        {
            _administradorRepository = administradorRepository;
        }
        public void Executar(Gestor gestor)
        {
            _administradorRepository.CriarGestor(gestor);
        }
    }
}