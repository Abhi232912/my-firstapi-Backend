namespace MyFirstWebApi.Services
{
    public interface IAuthService
    {
        string GenerateJWTToken(string username);
    }
}
