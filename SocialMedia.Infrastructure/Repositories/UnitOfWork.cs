﻿namespace SocialMedia.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly SocialMediaContext _context;
    private readonly IPostRepository _postRepository;
    private readonly IGenericRepository<User> _userRepository;
    private readonly IGenericRepository<Comment> _commentRepository;
    private readonly ISecurityRepository _securityRepository;

    public UnitOfWork(SocialMediaContext context)
    {
        _context = context;
    }
    public IPostRepository PostRepository => _postRepository ?? new PostRepository(_context);

    public IGenericRepository<User> UserRepository => _userRepository ?? new GenericRepository<User>(_context);

    public IGenericRepository<Comment> CommentRepository => _commentRepository ?? new GenericRepository<Comment>(_context);

    public ISecurityRepository SecurityRepository => _securityRepository ?? new SecurityRepository(_context);

    public void Dispose()
    {
        if (_context != null)
        {
            _context.Dispose();
        }
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
