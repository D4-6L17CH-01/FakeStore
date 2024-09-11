namespace Common.Rest;

public class RestLogin : ILogin
{
    public RestLogin(string baseUrl, string token) { http = new HttpHelper(baseUrl, token); }
    private readonly HttpHelper http;

    public async Task<string> LoginAsync(Login login)
    {
        var resp = await http.PostAsync<Login, Dictionary<string, string>>("auth/login", login);
        return resp["token"];
    }
}
