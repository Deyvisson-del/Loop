using Loop.Domain.Entities;
using Loop.Infra.Data.Context;

namespace Loop.Infra.Data.Repository
{
    public class AdministradorRepository : IAdministradorRepository
    {
        private readonly Contexto _contextAdministrador;
        public AdministradorRepository(Contexto contextAdministrador)
        {
            _contextAdministrador = contextAdministrador;
        }

        public void AtualizarEstagiario(int id)
        {
            throw new NotImplementedException();
        }

        public void AtualizarGestor(int id)
        {
            throw new NotImplementedException();
        }

        public Estagiario? ConsultaEstagiarioNome(string nome)
        {
            var estagiarioBuscado = _contextAdministrador.Estagiarios.FirstOrDefault(a => a.Nome == nome);
            if (estagiarioBuscado == null) throw new Exception("Nome inválido ou Não encontrado");

            return estagiarioBuscado;
        }


        public Estagiario? ConsultarEstagiarioId(int id)
        {
            var estagiarioBanco = _contextAdministrador.Estagiarios.Find(id);
            if (estagiarioBanco == null)
            {
                throw new Exception("Estagiário não encontrado");
            }
            return _contextAdministrador.Estagiarios.Find(id);
        }

        public Gestor? ConsultarGestorId(int id)
        {
            var gestorBanco = _contextAdministrador.Gestores.Find(id);
            if (gestorBanco == null)
            {
                throw new Exception("Gestor não encontrado");
            }
            return _contextAdministrador.Gestores.Find(id);
        }

        public IEnumerable<Estagiario> ConsultarListaEstagiario()
        {
            return _contextAdministrador.Estagiarios.ToList();
        }

        public IEnumerable<Gestor> ConsultarListaGestor()
        {
            return _contextAdministrador.Gestores.ToList();
        }

        public void CriarEstagiario(Estagiario estagiario)
        {
            _contextAdministrador.Estagiarios.Add(estagiario);
            _contextAdministrador.SaveChanges();
        }

        public void CriarGestor(Gestor gestor)
        {
            _contextAdministrador.Gestores.Add(gestor);
            _contextAdministrador.SaveChanges();
        }

        public void DeletarEstagiario(int id)
        {
            var estagiarioRemovido = ConsultarEstagiarioId(id);

            if (estagiarioRemovido == null) throw new Exception("ID inválido ou Id não corresponde a nenhum Estagiario");

            _contextAdministrador.Estagiarios.Remove(estagiarioRemovido);
            _contextAdministrador.SaveChanges();
        }

        public void DeletarGestor(int id)
        {
            var gestorRemovido = ConsultarGestorId(id);

            if (gestorRemovido == null) throw new Exception("ID inválido ou ID não corresponde a nenhum Gestor");

            _contextAdministrador.Gestores.Remove(gestorRemovido);
            _contextAdministrador.SaveChanges();
        }
    }
}
