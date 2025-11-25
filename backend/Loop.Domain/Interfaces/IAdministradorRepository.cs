using Loop.Domain.Entities;

namespace Loop.Domain.Interfaces
{
    public interface IAdministradorRepository
    {
        Task<Administrador?> ObterAdministradorPorId(int id);
        Task<Administrador?> ObterAdminiadorPorEmail(string email);
        Task CriarAsync(Administrador administrador);
    }
}
