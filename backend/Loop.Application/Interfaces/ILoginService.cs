using Loop.Domain.Entities;

namespace Loop.Application.Interfaces
{
    public interface ILoginService
    {
        Task<Perfil?> AutenticarAsync(string email, string senha);
    }
}
