namespace SocialMedia.Core.Interfaces.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Post> Post { get; }
        IGenericRepository<User> User { get; }
        IGenericRepository<Comment> Comment { get; }

        void SaveChange();
        Task SaveChangeAsync();
    }
}
