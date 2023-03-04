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
        public IPostRepository PostRepository => PostRepository ?? new PostRepository(_context);

        public IGenericRepository<User> UserRepository => UserRepository ?? new GenericRepository<User>(_context);

        public IGenericRepository<Comment> CommentRepository => CommentRepository ?? new GenericRepository<Comment>(_context);

        public void Dispose()
        {
            if (_context != null)
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
