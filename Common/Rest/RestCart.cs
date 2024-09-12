namespace Common.Rest;

public class RestCart : ICart
{
    public RestCart(string baseUrl, string token) { http = new HttpHelper(baseUrl, token); }
    private readonly HttpHelper http;

    public async Task<ICollection<Cart>> GetAllAsync()
        => await http.GetAsync<ICollection<Cart>>("carts");

    public async Task<Cart> GetAsync(int cartid)
        => await http.GetAsync<Cart>($"carts/{cartid}");

    public async Task<Cart> GetUserAsync(int userid)
        => await http.GetAsync<Cart>($"carts/user/{userid}");

    public async Task<Cart> InsertAsync(Cart carrito)
        => await http.PostAsync<Cart, Cart>("carts", carrito);

    public async Task<Cart> UpdateAsync(int id, Cart carrito)
        => await http.PutAsync<Cart, Cart>($"carts/{id}", carrito);

    public async Task<Cart> PatchAsync(int id, Cart carrito)
        => await http.PatchAsync<Cart, Cart>($"carts/{id}", carrito);

    public async Task<Cart> DeleteAsync(int id)
        => await http.DeleteAsync<Cart>($"carts/{id}");
}
