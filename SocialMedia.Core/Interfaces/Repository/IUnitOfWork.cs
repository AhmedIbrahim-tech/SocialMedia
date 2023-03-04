namespace SocialMedia.Core.Interfaces.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IPostRepository PostRepository { get; }
        IGenericRepository<User> UserRepository { get; }
        IGenericRepository<Comment> CommentRepository { get; }

        void SaveChange();
        Task SaveChangeAsync();
    }
}
