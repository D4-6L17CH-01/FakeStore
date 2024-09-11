namespace Common.Contracts;
public interface ILogin
{
    Task<string> LoginAsync(Login login);
}
