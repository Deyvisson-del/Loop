using Loop.Application.DTOs;

namespace Loop.Application.Interfaces
{
    public interface IEstagiarioService : IBaseService<EstagiarioDTO>
    {
        Task<EstagiarioDTO?> ObterPorEmailAsync(string email);

    }
}
