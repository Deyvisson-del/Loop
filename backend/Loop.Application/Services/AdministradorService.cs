using Loop.Application.Interfaces;
using Loop.Domain.Entities;
using Loop.Domain.Interfaces;

namespace Loop.Application.Services
{
    public class AdministradorService : IAdministradorService
    {
        private readonly IAdministradorRepository _administradorRepository;
        private readonly IEstagiarioRepository _estagiarioRepository;
        private readonly IGestorRepository _gestorRepository;
        private readonly IFrequenciaRepository _frequenciaRepository;
        private readonly ISolicitacaoRepository _solicitacaoRepository;

        public async Task CriarEstagiarioAsync(Estagiario estagiario)
        {
            estagiario = Estagiario

            await _estagiarioRepository.CriarEstagiarioAsync(estagiario);
        }

        public Task CriarGestorAsync(Gestor gestor)
        {
            throw new NotImplementedException();
        }
    }
}
