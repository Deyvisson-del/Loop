using Loop.Domain.Entities;
using Loop.Domain.Interfaces;

namespace Loop.Infra.Data.Repositories
{
    public class AdministradorRepository : IAdministradorRepository
    {
        public Task CriarAsync(Administrador administrador)
        {
            throw new NotImplementedException();
        }

        public Task<Administrador?> ObterAdminiadorPorEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Administrador?> ObterAdministradorPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
