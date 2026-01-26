using Loop.Domain.Entities;

namespace Loop.Application.UseCase.Gestor
{
    public class DeletarEstagiarioUseCase
    {
        private readonly IGestorRepository _gestorRepository;
        public DeletarEstagiarioUseCase(IGestorRepository gestorRepository)
        {
            _gestorRepository = gestorRepository;
        }
        public void Execute(int id)
        {
            _gestorRepository.DeletarEstagiario(id);
        }
    }
}