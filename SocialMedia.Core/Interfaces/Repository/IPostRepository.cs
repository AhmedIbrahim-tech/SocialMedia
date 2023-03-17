

namespace SocialMedia.Core.Interfaces.Repository
{
    public interface IPostRepository 
    {
        Task<IEnumerable<Post>> GetAll();
        Task<Post> GetById(int id);
        Task<bool> InsertPost(Post post);
        Task<bool> EditPost(Post entity);
        Task<bool> DeletePost(int id);
        Task<IEnumerable<Post>> GetPostsbyUser(int userid);
    }
}
