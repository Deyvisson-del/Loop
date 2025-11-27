using Loop.Application.Interfaces;
using Loop.Domain.Entities;

namespace Loop.Application.Services
{
    public class AdministradorService : IAdministradorService
    {
        public Task AprovarSolicitacaoAsync(int solicitacaoId)
        {
            throw new NotImplementedException();
        }

        public Task AtualizarEstagiarioAsync(int estagiarioId, Estagiario estagiario)
        {
            throw new NotImplementedException();
        }

        public Task AtualizarFrequenciasync(int frequenciaId, Frequencia frequencia)
        {
            throw new NotImplementedException();
        }

        public Task AtualizarGestorAsync(int gestorId, Gestor gestor)
        {
            throw new NotImplementedException();
        }

        public Task CriarEstagiarioAsync(Estagiario estagiario)
        {
            throw new NotImplementedException();
        }

        public Task CriarGestorAsync(Gestor gestor)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Frequencia>> GerarRelatorioFrequencia(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Estagiario?> ObterEstagiarioPorEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Estagiario?> ObterEstagiarioPorIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Frequencia?> ObterFrequenciaPorIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Gestor?> ObterGestorPorEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Gestor?> ObterGestorPorIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Solicitacao>> ObterSolicitacoesPendentesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Solicitacao?>> ObterTodasSolicitacoesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Estagiario?>> ObterTodosEstagiariosAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Gestor?>> ObterTodosGestoresAsync()
        {
            throw new NotImplementedException();
        }

        public Task RejeitarSolicitacaoAsync(int solicitacaoId, string motivoRejeicao)
        {
            throw new NotImplementedException();
        }

        public Task RemoverEstagiarioAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoverGestorAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
