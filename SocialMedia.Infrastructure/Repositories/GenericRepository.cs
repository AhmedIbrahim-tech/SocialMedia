
namespace SocialMedia.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly SocialMediaContext _context;

        public GenericRepository(SocialMediaContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<int> Add(T entity)
        {
            _context.Set<T>().AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Edit(T entity)
        {
            _context.Set<T>().Update(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            T CurrentEntity = await GetById(id);
            _context.Set<T>().Remove(CurrentEntity);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
