﻿
namespace SocialMedia.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly SocialMediaContext _context;

        public GenericRepository(SocialMediaContext context)
        {
            this._context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsEnumerable();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task Add(T entity)
        {
            _context.Set<T>().AddAsync(entity);
        }

        public async Task Edit(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public async Task Delete(int id)
        {
            T CurrentEntity = await GetById(id);
            _context.Set<T>().Remove(CurrentEntity);
        }
    }
}
