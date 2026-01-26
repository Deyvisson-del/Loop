using Loop.Domain.Entities;

namespace Loop.Application.UseCase.Gestor
{
    public class AtualizarEstagiarioUseCase
    {
        private readonly IGestorRepository _gestorRepository;
        public AtualizarEstagiarioUseCase(IGestorRepository gestorRepository)
        {
            _gestorRepository = gestorRepository;
        }
        public void Execute(Estagiario estagiario)
        {
            _gestorRepository.AtualizarEstagiario(estagiario);
        }
    }
}