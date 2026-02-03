namespace Loop.Domain.Entities
{
    public interface IAdministradorRepository
    {
        void CriarEstagiario(Estagiario estagiario);
        void CriarGestor(Gestor gestor);
        IEnumerable<Estagiario> BuscarListaEstagiario();
        IEnumerable<Gestor> BuscarListaGestor();
        Estagiario? BuscarEstagiarioId(int id);
        Gestor? BuscarGestorId(int id);
        IEnumerable<Estagiario> BuscarEstagiarioNome(string nome);
        IEnumerable<Gestor> BuscarGestorNome(string nome);
        void AtualizarEstagiario(Estagiario estagiarioAtualizado);
        void AtualizarGestor(Gestor gestorAtualizado);
        void DeletarEstagiario(Estagiario estagiario);
        void DeletarGestor(Gestor gestor);
    }
}