using Loop.Domain.Entities;

namespace Loop.Application.UseCase.Gestor
{
    public class CriarEstagiarioUseCase
    {
        private readonly IGestorRepository _gestorRepository;
        public CriarEstagiarioUseCase(IGestorRepository gestorRepository)
        {
            _gestorRepository = gestorRepository;
        }
        public void Executar(Estagiario estagiario)
        {
            _gestorRepository.CriarEstagiario(estagiario);
        }
    }
}