namespace KcentrParser.Services;

public interface IAuthService
{
    public string GetToken(string login);
}