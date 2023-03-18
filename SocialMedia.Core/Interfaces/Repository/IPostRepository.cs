

namespace SocialMedia.Core.Interfaces.Repository
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        Task<IEnumerable<Post>> GetPostsbyUser(int userid);
    }
}
