namespace SocialMedia.Core.Interfaces;

public interface IPasswordService
{
    string Hash(string password);

    bool Check(string hash, string password);
}
