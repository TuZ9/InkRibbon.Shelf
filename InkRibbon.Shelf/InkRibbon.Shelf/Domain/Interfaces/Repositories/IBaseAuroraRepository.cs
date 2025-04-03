namespace InkRibbon.Shelf.Domain.Interfaces.Repositories
{
    public interface IBaseAuroraRepository<TEntity> where TEntity : class
    {
        Task InsertAsync(string query, object? param = null);
        Task UpdateAsync(string query, object? param = null);
        Task DeleteAsync(string query, object? param = null);
        Task<IEnumerable<TEntity>> GetListAsync(string query, object? param = null);
        Task<TEntity> GetAsync(string query, object? param = null);
    }
}
