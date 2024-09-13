namespace Common.Rest;

//TODO: Implementar los metodos faltantes
public class RestCart : ICart
{
    public RestCart(string baseUrl, string token) { http = new HttpHelper(baseUrl, token); }
    private readonly HttpHelper http;

    public async Task<ICollection<Cart>> GetAllAsync()
        => throw new NotImplementedException();

    public async Task<Cart> GetAsync(int cartid)
        => await http.GetAsync<Cart>($"carts/{cartid}");

    public async Task<Cart> GetUserAsync(int userid)
        => await http.GetAsync<Cart>($"carts/user/{userid}");

    public async Task<Cart> InsertAsync(Cart carrito)
        => await http.PostAsync<Cart, Cart>("carts", carrito);

    public async Task<Cart> UpdateAsync(int id, Cart carrito)
        => await http.PutAsync<Cart, Cart>($"carts/{id}", carrito);

    public async Task<Cart> PatchAsync(int id, Cart carrito)
        => throw new NotImplementedException();

    public async Task<Cart> DeleteAsync(int id)
        => throw new NotImplementedException();
}
