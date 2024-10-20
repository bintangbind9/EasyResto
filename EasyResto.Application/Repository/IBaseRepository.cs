namespace EasyResto.Application.Repository
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task CreateAsync(T obj);
        Task UpdateAsync(Guid id, T obj);
        Task DeleteAsync(Guid id);
    }
}
