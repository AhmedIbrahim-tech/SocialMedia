namespace SocialMedia.Core.Interfaces.Repository
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<int> Add(T entity);
        Task<int> Edit(T entity);
        Task<bool> Delete(int id);
    }
}
