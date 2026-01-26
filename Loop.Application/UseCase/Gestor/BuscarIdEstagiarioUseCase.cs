using Loop.Domain.Entities;

namespace Loop.Application.UseCase.Gestor
{
    public class BuscarIdEstagiarioUseCase
    {
        private readonly IGestorRepository _gestorRepository;
        public BuscarIdEstagiarioUseCase(IGestorRepository gestorRepository)
        {
            _gestorRepository = gestorRepository;
        }
        public Estagiario? Executar(int id) 
        {
            return _gestorRepository.BuscarIdEstagiario(id);
        }
    }
}