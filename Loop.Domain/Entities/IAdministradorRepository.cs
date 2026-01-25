namespace Loop.Domain.Entities
{
    public interface IAdministradorRepository
    {
        void CriarEstagiario(Estagiario estagiario);
        void CriarGestor(Gestor gestor);

        IEnumerable<Estagiario> ConsultarListaEstagiario();
        IEnumerable<Gestor> ConsultarListaGestor();

        Estagiario? ConsultarEstagiarioId(int id);
        Gestor? ConsultarGestorId(int id);
        Estagiario? ConsultaEstagiarioNome(string nome);
        Gestor? BuscarGestorNome(string nome);

        void AtualizarEstagiario(Estagiario estagiarioAtualizado);
        void AtualizarGestor(Gestor gestorAtualizado);

        void DeletarEstagiario(int id);
        void DeletarGestor(int id);
    }
}