namespace Loop.Domain.Entities
{
    public interface IGestorRepository
    {
        void CriarEstagiario(Estagiario estagiario);
        IEnumerable<Estagiario> BuscarListaEstagiario();
        Estagiario? BuscarIdEstagiario(int id);
        IEnumerable<Estagiario> BuscarNomeEstagiario(string nomeBusca);
        void AtualizarEstagiario(Estagiario estagiario);
        void DeletarEstagiario(int id);
    }
}