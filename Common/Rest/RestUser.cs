namespace Common.Rest;

//TODO: Implementar los metodos faltantes
public class RestUser : IUser
{
    private readonly HttpHelper http;
    public RestUser(string baseUrl, string token)
        => http = new HttpHelper(baseUrl, token);

    public async Task<ICollection<User>> GetAllAsync()
        => await http.GetAsync<ICollection<User>>("users");

    public async Task<User> GetAsync(int id)
        => throw new NotImplementedException();

    public async Task<User> InsertAsync(User usuario)
        => throw new NotImplementedException();

    public async Task<User> UpdateAsync(int id, User usuario)
        => throw new NotImplementedException();

    public async Task<User> DeleteAsync(int id)
        => await http.DeleteAsync<User>($"users/{id}");
}
