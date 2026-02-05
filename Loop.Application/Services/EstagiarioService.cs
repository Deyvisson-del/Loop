using Loop.Domain.Interfaces;
using Loop.Domain.Requests;

namespace Loop.Application.Services
{
    public class EstagiarioService
    {
        private readonly IEstagiarioRepository _estagiarioRepository;

        public EstagiarioService(IEstagiarioRepository estagiarioService)
        {
            _estagiarioRepository = estagiarioService;
        }

        public void BaterEntrada(int estagiarioId, DateTime entrada)
        {
            
        }

        public void BaterSaida()
        {
           
        }

        public void SolicitarAjuste(Solicitacao solicitacao)
        {
            _estagiarioRepository.SolicitarAjuste(solicitacao);
        }
    }
}