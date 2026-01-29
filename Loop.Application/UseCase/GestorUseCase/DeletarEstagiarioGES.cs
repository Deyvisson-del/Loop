using Loop.Domain.Entities;

namespace Loop.Application.UseCase.Gestor
{
    public class DeletarEstagiarioGES
    {
        private readonly IGestorRepository _gestorRepository;
        public DeletarEstagiarioGES(IGestorRepository gestorRepository)
        {
            _gestorRepository = gestorRepository;
        }
        public void Execute(int id)
        {
            _gestorRepository.DeletarEstagiario(id);
        }
    }
}