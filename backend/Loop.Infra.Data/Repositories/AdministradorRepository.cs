using Loop.Domain.Entities;
using Loop.Domain.Interfaces;
using Loop.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Loop.Infra.Data.Repositories
{
    public class AdministradorRepository : IAdministradorRepository
    {

        private readonly LoopDbContext _context;

        public AdministradorRepository(LoopDbContext context)
        {
            _context = context;
        }

        public async Task AtualizarAsync(Administrador administrador)
        {
            _context.Administradores.Update(administrador);
            await _context.SaveChangesAsync();
        }

        public async Task CriarAsync(Administrador administrador)
        {
            await _context.Administradores.AddAsync(administrador);
            await _context.SaveChangesAsync();
        }

        public async Task DeletarAsync(int id)
        {
            var adm = await ObterAdministradorPorId(id);
            if (adm != null)
            {
                _context.Administradores.Remove(adm);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Administrador?> ObterAdminiadorPorEmail(string email)
        {
            return await _context.Administradores.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<Administrador?> ObterAdministradorPorId(int id)
        {
            return await _context.Administradores.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Administrador?>> ObterTodosAdministradoresAsync()
        {
            return await _context.Administradores.AsNoTracking().ToListAsync();
        }
    }
}
