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

        public Gestor? BuscarGestorPorId(int id)
        {
            try
            {
                var gestorEncontrado = _administradorRepository.BuscarGestorId(id);
                return gestorEncontrado;
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
            Estagiario estagiarioRemovido = BuscarEstagiarioPorId(id) ?? throw new Exception("ID inválido ou Id não corresponde a nenhum Estagiario");
            _administradorRepository.DeletarEstagiario(estagiarioRemovido);
        }

        public void DeletarGestor(int id)
        {
            Gestor gestorRemovido = BuscarGestorPorId(id) ?? throw new Exception("ID inválido ou Id não corresponde a nenhum Gestor");
            _administradorRepository.DeletarGestor(gestorRemovido);
        }

    }
}