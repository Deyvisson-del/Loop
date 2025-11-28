using Loop.Domain.Entities;
using Loop.Domain.Interfaces;
using Loop.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Loop.Infra.Data.Repositories
{
    public class AdministradorRepository : IAdministradorRepository
    {

        private readonly LoopDbContext _contextAdministrador;

        public AdministradorRepository(LoopDbContext contextAdministrador)
        {
            _contextAdministrador = contextAdministrador;
        }

        public async Task AtualizarAdministradorAsync(Administrador administrador)
        {
            _contextAdministrador.Administradores.Update(administrador);
            await _contextAdministrador.SaveChangesAsync();
        }

        public async Task CriarAdministradorAsync(Administrador administrador)
        {
            await _contextAdministrador.Administradores.AddAsync(administrador);
            await _contextAdministrador.SaveChangesAsync();
        }

        public async Task DeletarAdministradorAsync(Administrador administrador)
        {
            _contextAdministrador.Administradores.Remove(administrador);
            await _contextAdministrador.SaveChangesAsync();
        }

        public async Task<Administrador?> ObterAdministradorPorIdAsync(int id)
        {
            return await _contextAdministrador.Administradores.FindAsync(id) ??
                throw new InvalidOperationException("Administrador não encontrado.");
        }

        public async Task<Administrador?> ObterAdminiadorPorEmailAsync(string email)
        {
            return await _contextAdministrador.Administradores.FirstOrDefaultAsync(x => x.Email == email) ??
                throw new InvalidOperationException("Administrador não encontrado.");
        }

        public async Task<IEnumerable<Administrador?>> ObterTodosAdministradoresAsync()
        {
            return await _contextAdministrador.Administradores.AsNoTracking().ToListAsync() ??
                throw new InvalidOperationException("Administradores não encontrados");
        }
    }
}
