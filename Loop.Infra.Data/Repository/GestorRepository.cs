using Loop.Infra.Data.Context;
using Loop.Domain.Entities;

namespace Loop.Infra.Data.Repository
{
    public class GestorRepository : IGestorRepository
    {
        private readonly Contexto _contextGestor;
        public GestorRepository(Contexto contextoGestor)
        {
            _contextGestor = contextoGestor;
        }

        public void CriarEstagiario(Estagiario estagiario)
        {
            _contextGestor.Estagiarios.Add(estagiario);
            _contextGestor.SaveChanges();
        }

        public IEnumerable<Estagiario> BuscarListaEstagiario()
        {
            return _contextGestor.Estagiarios.ToList();
        }

        public void AtualizarEstagiario(Estagiario estagiarioModificado)
        {
            _contextGestor.Estagiarios.Update(estagiarioModificado);
            _contextGestor.SaveChanges();
        }

        public IEnumerable<Estagiario> BuscarNomeEstagiario(string nomeBusca)
        {
            var estagiarioExiste = _contextGestor.Estagiarios.Where(x => x.Nome == nomeBusca);
            if (estagiarioExiste == null) throw new Exception("Estagiário não encontrado ");
            return estagiarioExiste;
        }

        public Estagiario? BuscarIdEstagiario(int id)
        {
            var gestorExiste = _contextGestor.Estagiarios.Find(id);
            if (gestorExiste == null) throw new Exception("Id não encontrado");
            return gestorExiste;
        }

        public void DeletarEstagiario(int id)
        {
            var estagiarioRemovido = BuscarIdEstagiario(id);
            if (estagiarioRemovido == null) throw new Exception("ID inválido ou Id não corresponde a nenhum Estagiario");
            _contextGestor.Estagiarios.Remove(estagiarioRemovido);
            _contextGestor.SaveChanges();
        }
    }
}