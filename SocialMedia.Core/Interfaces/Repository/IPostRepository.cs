namespace SocialMedia.Core.Interfaces.Repository
{
    public interface IPostRepository
    {
        Task<BaseGenericResult<IEnumerable<Post>>> GetPosts();
        Task<BaseGenericResult<Post>> GetPost(int id);
        Task<BaseGenericResult<int>> InsertPost(Post dto);
        Task<BaseGenericResult<int>> EditPost(Post dto);
        Task<BaseGenericResult<bool>> DeletePost(int id);
    }
}
