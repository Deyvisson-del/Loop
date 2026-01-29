using Loop.Domain.Entities;

namespace Loop.Application.UseCase.Gestor
{
    public class BuscarIdEstagiarioGES
    {
        private readonly IGestorRepository _gestorRepository;
        public BuscarIdEstagiarioGES(IGestorRepository gestorRepository)
        {
            _gestorRepository = gestorRepository;
        }
        public Domain.Entities.Estagiario? Executar(int id)
        {
            return _gestorRepository.BuscarIdEstagiario(id);
        }
    }
}