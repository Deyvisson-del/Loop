using Loop.Domain.Entities;

namespace Loop.Application.UseCase.Gestor
{
    public class BuscarNomeEstagiarioUseCase
    {
        private readonly IGestorRepository _gestorRepository;
        public BuscarNomeEstagiarioUseCase(IGestorRepository gestorRepository)
        {
            _gestorRepository = gestorRepository;
        }
        public IEnumerable<Estagiario> Executar(string nomeBusca)
        {
            return _gestorRepository.BuscarNomeEstagiario(nomeBusca);
        }
    }
}