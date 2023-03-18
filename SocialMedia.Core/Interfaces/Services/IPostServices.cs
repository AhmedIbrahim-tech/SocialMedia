using SocialMedia.Core.CustomEntities;

namespace SocialMedia.Core.Interfaces.Services
{
    public interface IPostServices
    {
        PagedList<Post> GetPosts(PostQueryFilter filters);
        Task<Post> GetPost(int id);
        Task<bool> InsertPost(Post dto);
        Task<bool> EditPost(Post dto);
        Task<bool> DeletePost(int id);
        
        //Task<int> SavePost(Post dto);
    }
}
