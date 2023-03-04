namespace SocialMedia.Core.Interfaces.Services
{
    public interface IPostServices
    {
        Task<IEnumerable<Post>> GetPosts();
        Task<Post> GetPost(int id);
        Task<int> SavePost(Post dto);
        Task<int> InsertPost(Post dto);
        Task<int> EditPost(Post dto);
        Task<int> DeletePost(int id);
    }
}
