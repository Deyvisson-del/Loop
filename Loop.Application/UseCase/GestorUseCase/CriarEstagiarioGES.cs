using Loop.Domain.Entities;

namespace Loop.Application.UseCase.Gestor
{
    public class CriarEstagiarioGES
    {
        private readonly IGestorRepository _gestorRepository;
        public CriarEstagiarioGES(IGestorRepository gestorRepository)
        {
            _gestorRepository = gestorRepository;
        }
        public void Executar(Domain.Entities.Estagiario estagiario)
        {
            _gestorRepository.CriarEstagiario(estagiario);
        }
    }
}