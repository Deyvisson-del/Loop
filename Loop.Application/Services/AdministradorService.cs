using Loop.Domain.Entities;

namespace Loop.Application.Services
{
    public class AdministradorService
    {
        private readonly IAdministradorRepository _administradorRepository;

        public AdministradorService(IAdministradorRepository administradorRepository)
        {
            _administradorRepository = administradorRepository;
        }

        public void AtualizarEstagiario(Estagiario estagiario)
        {
            _administradorRepository.AtualizarEstagiario(estagiario);
        }

        public void AtualizarGestor(Gestor gestor)
        {
            _administradorRepository.AtualizarGestor(gestor);
        }

        public void CriarEstagiario(Estagiario estagiario)
        {
            _administradorRepository.CriarEstagiario(estagiario);
        }

        public void CriarGestor(Gestor gestor)
        {
            _administradorRepository.CriarGestor(gestor);
        }

        public Estagiario? BuscarEstagiarioPorId(int id)
        {
            try
            {
                var EstagiarioEncontrado = _administradorRepository.BuscarEstagiarioId(id);
                return EstagiarioEncontrado;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Estagiario> BuscarNomeEstagiario(string nome)
        {
            return _administradorRepository.BuscarEstagiarioNome(nome);
        }

        public IEnumerable<Gestor> BuscarNomeGestor(string nomeGestor)
        {
            return _administradorRepository.BuscarGestorNome(nomeGestor);
        }

        public IEnumerable<Estagiario> ListaDeEstagiarios()
        {
            return _administradorRepository.BuscarListaEstagiario();
        }

        public IEnumerable<Gestor> ListaDeGestores()
        {
            return _administradorRepository.BuscarListaGestor();
        }

        public void DeletarEstagiario(int id)
        {
            try
            {
                _administradorRepository.BuscarEstagiarioId(id);
                _administradorRepository.DeletarEstagiario(id);

            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }

        }

        public void DeletarGestor(int id)
        {
            _administradorRepository.DeletarGestor(id);
        }

    }
}