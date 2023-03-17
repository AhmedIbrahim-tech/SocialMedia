namespace SocialMedia.Core.Interfaces.Repository;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAll();
    Task<User> GetById(int id);

}
