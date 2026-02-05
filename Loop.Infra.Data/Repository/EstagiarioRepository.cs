using Loop.Domain.Interfaces;
using Loop.Domain.Requests;
using Loop.Infra.Data.Context;

namespace Loop.Infra.Data.Repository
{
    public class EstagiarioRepository : IEstagiarioRepository
    {
        private readonly Contexto _contexto;

        public EstagiarioRepository(Contexto contexto)
        {
            _contexto = contexto;
        }
        public void BaterEntrada(Frequencia frequencia)
        {
            _contexto.Frequencias.Add(frequencia);
        }

        public void BaterSaida(Frequencia frequencia)
        {
            _contexto.Frequencias.Add(frequencia);
        }

        public void SolicitarAjuste(Solicitacao solicitacao)
        {
            _contexto.Solicitacoes.Add(solicitacao);
        }
    }
}