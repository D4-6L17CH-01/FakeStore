using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Rest;

public class RestUser : IUser
{
    private readonly HttpHelper http;
    public RestUser(string baseUrl, string token)
        => http = new HttpHelper(baseUrl, token);
    public async Task<bool> DeleteAsync(int id)
        => await http.DeleteAsync($"users/{id}");

    public async Task<ICollection<User>> GetAllAsync()
        => await http.GetAsync<ICollection<User>>("users");

    public async Task<User> GetAsync(int id)
        => await http.GetAsync<User>("users/{id}");

    public async Task<User> InsertAsync(User usuario)
        => await http.PostAsync<User, User>($"users", usuario);

    public async Task<User> UpdateAsync(int id, User usuario)
        => await http.PutAsync<User, User>($"users", usuario);
}
