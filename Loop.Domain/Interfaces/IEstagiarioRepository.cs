namespace Loop.Domain.Interfaces
{
    public interface IEstagiarioRepository
    {
        Task<bool> ValidarCredenciaisAsync(string email, string senha);
    }
}