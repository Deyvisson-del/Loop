using Loop.Domain.Entities;

namespace Loop.Application.UseCase.Gestor
{
    public class BuscarNomeEstagiarioGES
    {
        private readonly IGestorRepository _gestorRepository;
        public BuscarNomeEstagiarioGES(IGestorRepository gestorRepository)
        {
            _gestorRepository = gestorRepository;
        }
        public IEnumerable<Domain.Entities.Estagiario> Executar(string nomeBusca)
        {
            return _gestorRepository.BuscarNomeEstagiario(nomeBusca);
        }
    }
}