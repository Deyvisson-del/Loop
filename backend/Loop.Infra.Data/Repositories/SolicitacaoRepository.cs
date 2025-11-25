using Loop.Domain.Entities;
using Loop.Domain.Interfaces;

namespace Loop.Infra.Data.Repositories
{
    public class SolicitacaoRepository : ISolicitacaoRepository
    {
        public Task AtualizarAsync(Solicitacao solicitacao)
        {
            throw new NotImplementedException();
        }

        public Task<Solicitacao> CriarSolicitacaoAsync(Solicitacao solicitacao)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Solicitacao>> ObterPorEstagiarioIdAsync(int estagiarioId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Solicitacao>> ObterPorPendentesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Solicitacao> ObterSolicitacaoPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
