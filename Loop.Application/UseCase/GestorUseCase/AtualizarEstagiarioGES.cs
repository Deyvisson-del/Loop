using Loop.Domain.Entities;

namespace Loop.Application.UseCase.Gestor
{
    public class AtualizarEstagiarioGES
    {
        private readonly IGestorRepository _gestorRepository;
        public AtualizarEstagiarioGES(IGestorRepository gestorRepository)
        {
            _gestorRepository = gestorRepository;
        }
        public void Execute(Domain.Entities.Estagiario estagiario)
        {
            _gestorRepository.AtualizarEstagiario(estagiario);
        }
    }
}