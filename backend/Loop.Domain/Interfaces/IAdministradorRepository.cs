using Loop.Domain.Entities;

namespace Loop.Domain.Interfaces
{
    public interface IAdministradorRepository
    {

        Task<Administrador?> ObterAdministradorPorId(int id);
        Task<Administrador?> ObterAdminiadorPorEmail(string email);
        Task<IEnumerable<Administrador?>> ObterTodosAdministradoresAsync();
        Task CriarAsync(Administrador administrador);
        Task AtualizarAsync(Administrador administrador);
        Task DeletarAsync(int id);
    }
}
