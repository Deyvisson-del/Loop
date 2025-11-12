namespace Loop.Application.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        Task<IEnumerable<T>> ObterTodasAsync();
        Task<T?> ObterPorIdAsync(Guid id);
        Task AdicionarAsync(T dto);
        Task AtualizarAsync(T dto);
        Task RemoverAsync(Guid id);
    }
}
