using Loop.Application.Interfaces;
using Loop.Domain.Entities;
using Loop.Domain.Interfaces;

namespace Loop.Application.Services
{
    public class LoginService : ILoginService
    {
        private readonly IEstagiarioRepository _estagiarioRepository;
        private readonly IGestorRepository _gestorRepository;

        public LoginService(IEstagiarioRepository estagiarioRepository, IGestorRepository gestorRepository)
        {
            _estagiarioRepository = estagiarioRepository;
            _gestorRepository = gestorRepository;
        }
        public async Task<Perfil?> AutenticarAsync(string email, string senha)
        {
            var estagiario = await _estagiarioRepository.ObterPorEmailAsync(email);
            if(estagiario != null && estagiario.VerificarSenha(senha))
            {
                return estagiario;
            }

            var gestor = await _gestorRepository.ObterGestorPorEmailAsync(email);
            if(gestor != null && gestor.VerificarSenha(senha))
            {
                return gestor;
            }
            return null;
        }
    }
}
