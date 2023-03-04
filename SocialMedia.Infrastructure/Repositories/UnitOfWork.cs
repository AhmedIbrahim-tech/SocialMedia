using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SocialMediaContext _context;

        public UnitOfWork(SocialMediaContext context)
        {
            this._context = context;
        }
        public IGenericRepository<Post> Post => Post ?? new GenericRepository<Post>(_context);

        public IGenericRepository<User> User => User ?? new GenericRepository<User>(_context);

        public IGenericRepository<Comment> Comment => Comment ?? new GenericRepository<Comment>(_context);

        public void Dispose()
        {
            if (_context is not null)
            {
                _context.Dispose();
            }
        }

        public void SaveChange()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
