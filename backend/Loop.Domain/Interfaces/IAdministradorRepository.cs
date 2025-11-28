using Loop.Domain.Entities;

namespace Loop.Domain.Interfaces
{
    public interface IAdministradorRepository
    {
        Task CriarAdministradorAsync(Administrador administrador);
        Task AtualizarAdministradorAsync(Administrador administrador);
        Task DeletarAdministradorAsync(Administrador administrador);


        Task<Administrador> ObterAdministradorPorIdAsync(int id);
        Task<Administrador> ObterAdminiadorPorEmailAsync(string email);
        Task<IEnumerable<Administrador>> ObterTodosAdministradoresAsync();
    }
}
