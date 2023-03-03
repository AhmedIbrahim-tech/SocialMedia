namespace SocialMedia.Core.Interfaces.Repository
{
    public interface IUserRepository
    {
        Task<BaseGenericResult<IEnumerable<User>>> GetUsers();
        Task<BaseGenericResult<User>> GetUser(int id);
    }
}
