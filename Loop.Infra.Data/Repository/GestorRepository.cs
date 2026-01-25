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

        public void BuscarListaEstagiario()
        {
            throw new NotImplementedException();
        }

        public void AtualizarEstagiario(Estagiario estagiario)
        {
            throw new NotImplementedException();
        }

        public Estagiario? BuscarNomeEstagiario(string nome)
        {
            throw new NotImplementedException();
        }

        public Estagiario? BuscarIdEstagiario(int id)
        {
            throw new NotImplementedException();
        }

        public void DeletarEstagiario(int id)
        {
            throw new NotImplementedException();
        }

    }
}