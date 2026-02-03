using Loop.Domain.Entities;

namespace Loop.Application.Services
{
    public class GestorService
    {
        private readonly GestorService _gestorRepository;

        public GestorService(GestorService gestorService)
        {
            _gestorRepository = gestorService;
        }
        public void CriarEstagiario(Estagiario estagiario)
        {
            _gestorRepository.CriarEstagiario(estagiario);
        }

        public void BuscarIdEstagiario(int id)
        {
            _gestorRepository.BuscarIdEstagiario(id);
        }

        public void BuscarNomeEstagiario(string nome)
        {
            _gestorRepository.BuscarNomeEstagiario(nome);
        }

        public void BuscarListaEstagiario()
        {
            _gestorRepository.BuscarListaEstagiario();
        }

        public void AtualizarEstagiario(Estagiario estagiarioAtualizado)
        {
            _gestorRepository.AtualizarEstagiario(estagiarioAtualizado);
        }

        public void DeletarEstagiario(int id)
        {
            _gestorRepository.DeletarEstagiario(id);
        }
    }
}