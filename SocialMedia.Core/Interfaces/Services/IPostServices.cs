namespace SocialMedia.Core.Interfaces.Services
{
    public interface IPostServices
    {
        IEnumerable<Post> GetPosts();
        Task<Post> GetPost(int id);

        //Task<int> SavePost(Post dto);
        
        Task InsertPost(Post dto);
        Task<bool> EditPost(Post dto);
        Task<bool> DeletePost(int id);
    }
}
