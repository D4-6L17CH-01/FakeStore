namespace Common.Tools;

public class HttpHelper
{
    public HttpHelper(string baseUrl, string token = "") { _baseUrl = baseUrl; _token = token; }
    private readonly string _baseUrl;
    private readonly string _token;

}
