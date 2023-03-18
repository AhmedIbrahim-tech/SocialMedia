namespace SocialMedia.Core.Interfaces.Services;

public interface ISecurityService
{
    Task<Security> GetLoginByCredentials(UserLogin userLogin);
    Task RegisterUser(Security security);
}
