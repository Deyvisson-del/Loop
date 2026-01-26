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

        public void AtualizarEstagiario(Estagiario estagiarioModificado)
        {
            _contextAdministrador.Estagiarios.Update(estagiarioModificado);
            _contextAdministrador.SaveChanges();
        }

        public void AtualizarGestor(Gestor gestorModificado)
        {
            _contextAdministrador.Gestores.Update(gestorModificado);
            _contextAdministrador.SaveChanges();
        }

        public IEnumerable<Gestor> BuscarGestorNome(string nomeGestor)
        {
            var gestorExiste = _contextAdministrador.Gestores.Where(x => x.Nome == nomeGestor);
            if (gestorExiste == null) throw new Exception("Gestor não encontrado");
            return gestorExiste;
        }

        public IEnumerable<Estagiario> BuscarEstagiarioNome(string nome)
        {
            var estagiarioBuscado = _contextAdministrador.Estagiarios.Where(a => a.Nome == nome);
            if (estagiarioBuscado == null) throw new Exception("Nome inválido ou Não encontrado");

            return estagiarioBuscado;
        }

        public Estagiario? BuscarEstagiarioId(int id)
        {
            var estagiarioBanco = _contextAdministrador.Estagiarios.Find(id);
            if (estagiarioBanco == null) throw new Exception("Estagiário não encontrado");

            return _contextAdministrador.Estagiarios.Find(id);
        }

        public Gestor? BuscarGestorId(int id)
        {
            var gestorBanco = _contextAdministrador.Gestores.Find(id);
            if (gestorBanco == null) throw new Exception("Gestor não encontrado");
            
            return _contextAdministrador.Gestores.Find(id);
        }

        public IEnumerable<Estagiario> BuscarListaEstagiario()
        {
            return _contextAdministrador.Estagiarios.ToList();
        }

        public IEnumerable<Gestor> BuscarListaGestor()
        {
            return _contextAdministrador.Gestores.ToList();
        }

        public void CriarEstagiario(Estagiario novoEstagiario)
        {
            _contextAdministrador.Estagiarios.Add(novoEstagiario);
            _contextAdministrador.SaveChanges();
        }

        public void CriarGestor(Gestor gestor)
        {
            _contextAdministrador.Gestores.Add(gestor);
            _contextAdministrador.SaveChanges();
        }

        public void DeletarEstagiario(int id)
        {
            var estagiarioRemovido = BuscarEstagiarioId(id);
            if (estagiarioRemovido == null) throw new Exception("ID inválido ou Id não corresponde a nenhum Estagiario");
            _contextAdministrador.Estagiarios.Remove(estagiarioRemovido);
            _contextAdministrador.SaveChanges();
        }

        public void DeletarGestor(int id)
        {
            var gestorRemovido = BuscarGestorId(id);
            if (gestorRemovido == null) throw new Exception("ID inválido ou ID não corresponde a nenhum Gestor");
            _contextAdministrador.Gestores.Remove(gestorRemovido);
            _contextAdministrador.SaveChanges();
        }
    }
}