using Loop.Application.DTOs;


namespace Loop.Application.Interfaces
{
    public interface IGestorService
    {
        Task<EstagiarioDTO?> ObterPorEmailAsync(string email);
    }
}
