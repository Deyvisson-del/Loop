using Loop.Application.DTOs;
using Loop.Application.Interfaces;

namespace Loop.Application.Services
{
    public class GestorService : IGestorService
    {
        public Task<EstagiarioDTO> AdicionarAsync(EstagiarioDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task AtualizarAsync(int id, EstagiarioDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<EstagiarioDTO?> ObterPorEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<EstagiarioDTO?> ObterPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EstagiarioDTO>> ObterTodosAsync()
        {
            throw new NotImplementedException();
        }

        public Task RemoverAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
