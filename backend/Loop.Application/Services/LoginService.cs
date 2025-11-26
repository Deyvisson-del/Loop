using Loop.Application.Interfaces;
using Loop.Domain.Entities;
using Loop.Domain.Interfaces;

namespace Loop.Application.Services
{
    public class LoginService
    {
        private readonly IEstagiarioRepository _estagiarioRepository;
        private readonly IGestorRepository _gestorRepository;

        public LoginService(IEstagiarioRepository estagiarioRepository, IGestorRepository gestorRepository)
        {
            _estagiarioRepository = estagiarioRepository;
            _gestorRepository = gestorRepository;
        }

    }
}
