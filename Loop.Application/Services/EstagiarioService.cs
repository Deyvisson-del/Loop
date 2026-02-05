using Loop.Domain.Entities;
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

        public void BaterEntrada()
        {
            Frequencia frequencia = new Frequencia(
                    
                );   
            _estagiarioRepository.BaterEntrada(frequencia);
        }

        public void BaterSaida()
        {
            Frequencia frequencia = new Frequencia(
                    
                );   
            _estagiarioRepository.BaterSaida(frequencia);
        }

        public void SolicitarAjuste(Solicitacao solicitacao)
        {
            _estagiarioRepository.SolicitarAjuste(solicitacao);
        }
    }
}