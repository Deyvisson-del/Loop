namespace Loop.Domain.Interfaces
{
    public interface IFrequenciaRepository
    {
        Task<bool> ValidarCredenciaisAsync(string email, string senha);
    }
}