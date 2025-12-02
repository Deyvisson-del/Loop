using Loop.Application.DTOs;
using Loop.Application.Interfaces;
using Loop.Domain.Entities;
using Loop.Domain.Interfaces;

namespace Loop.Application.Services
{
    public class GestorService : IGestorService
    {

        private readonly IGestorRepository _gestorRepository;
        private readonly IEstagiarioRepository _estagiarioRepository;
        private readonly ISolicitacaoRepository _solicitacaoRepository;

        public GestorService(IGestorRepository gestorRepository)
        {
            _gestorRepository = gestorRepository;
        }

        public Task AprovarSolicitacaoAsync(int solicitacaoId)
        {
            throw new NotImplementedException();
        }

        public Task AtualizarEstagiarioAsync(int estagiarioId, Estagiario estagiario)
        {
            throw new NotImplementedException();
        }

        public async Task CriarEstagiarioAsync(Estagiario estagiario)
        {
            await _estagiarioRepository.CriarEstagiarioAsync(estagiario);
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

        public Task RejeitarSolicitacaoAsync(int solicitacaoId, string motivoRejeicao)
        {
            throw new NotImplementedException();
        }

        public Task RemoverEstagiarioAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}