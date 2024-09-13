namespace Common.Rest;

public class RestRepository : IRepository
{
    private string token;
    public void SetToken(string token)
        => this.token = token;  
    private string url;
    public void SetUrl(string url)
        => this.url = url;
    public RestRepository(string url_)
        => this.url = url_;
    public IProducts Products => new RestProduct(url, token);

    public ICart Cart => new RestCart(url, token);

    public IUser User => new RestUser(url, token);

    public ILogin Login => new RestLogin(url, token);
}
