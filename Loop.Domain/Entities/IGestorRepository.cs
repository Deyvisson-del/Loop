namespace Loop.Domain.Entities
{
    public interface IGestorRepository
    {
        void CriarEstagiario(Estagiario estagiario);
        void BuscarListaEstagiario();
        Estagiario? BuscarIdEstagiario(int id);
        Estagiario? BuscarNomeEstagiario(string nome);
        void AtualizarEstagiario(Estagiario estagiario);
        void DeletarEstagiario(int id);
    }
}