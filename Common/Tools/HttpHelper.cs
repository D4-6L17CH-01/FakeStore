using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;

namespace Common.Tools;

public class HttpHelper
{
    public HttpHelper(string baseUrl, string token = "") { _baseUrl = baseUrl; _token = token; }
    private readonly string _baseUrl;
    private readonly string _token;
    
    private HttpClient BaseClient()
    {
        var c = new HttpClient(new SocketsHttpHandler { ConnectTimeout = TimeSpan.FromSeconds(30) }, true)
        { BaseAddress = new Uri(_baseUrl), Timeout = TimeSpan.FromMinutes(8) };

        if (!string.IsNullOrWhiteSpace(_token))
            c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
        return c;
    }



    private void ValidateUri(string uri)
    {
        if (uri.Length > 2000)
            throw new Exception("URI muy larga");
    }

    public async Task<TResult> GetAsync<TResult>(string controller)
    {
        ValidateUri(controller);
        using (var client = BaseClient())
        {
            var response = await client.GetAsync(controller);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                dynamic obj;
                if (typeof(TResult).Equals(typeof(string)))
                    obj = json;
                else
                    obj = JsonConvert.DeserializeObject<TResult>(json)!;
                return obj;
            }
            else
            {
                await ThrowError(response);
                return default;
            }
        }
    }

    public async Task<TResult> PostAsync<TRequest, TResult>(string controller, TRequest body)
    {
        ValidateUri(controller);
        using (var client = BaseClient())
        {
            var bodyrequest = new MyJson.JsonStringContent(body);
            var response = await client.PostAsync(controller, bodyrequest);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                dynamic obj;
                if (typeof(TResult).Equals(typeof(string)))
                    obj = json;
                else
                    obj = JsonConvert.DeserializeObject<TResult>(json)!;
                return obj;
            }
            else
            {
                await ThrowError(response);
                return default;
            }
        }
    }

    public async Task<TResult> PatchAsync<TRequest, TResult>(string controller, TRequest body)
    {
        ValidateUri(controller);
        using (var client = BaseClient())
        {
            var bodyrequest = new MyJson.JsonStringContent(body);
            var response = await client.PatchAsync(controller, bodyrequest);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                dynamic obj;
                if (typeof(TResult).Equals(typeof(string)))
                    obj = json;
                else
                    obj = JsonConvert.DeserializeObject<TResult>(json)!;
                return obj;
            }
            else
            {
                await ThrowError(response);
                return default;
            }
        }
    }

    public async Task<TResult> PutAsync<TRequest, TResult>(string controller, TRequest body)
    {
        ValidateUri(controller);
        using (var client = BaseClient())
        {
            var response = await client.PutAsync($"{controller}", new MyJson.JsonStringContent(body));
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                dynamic obj;
                if (typeof(TResult).Equals(typeof(string)))
                    obj = json;
                else
                    obj = JsonConvert.DeserializeObject<TResult>(json)!;
                return obj;
            }
            else
            {
                await ThrowError(response);
                return default!;
            }
        }
    }

    public async Task<TResult> DeleteAsync<TResult>(string controller)
    {
        ValidateUri(controller);
        using (var client = BaseClient())
        {
            var response = await client.GetAsync(controller);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                dynamic obj;
                if (typeof(TResult).Equals(typeof(string)))
                    obj = json;
                else
                    obj = JsonConvert.DeserializeObject<TResult>(json)!;
                return obj;
            }
            else
            {
                await ThrowError(response);
                return default;
            }
        }
    }

    private async Task ThrowError(HttpResponseMessage response)
    {
        var content = await response.Content.ReadAsStringAsync();
        var status = $"{(int)response.StatusCode}-{response.ReasonPhrase}\n{response.RequestMessage.RequestUri}";

        response.Content?.Dispose();
        RequestError requesterror;
        Exception error = null;

        // intentar sacar solo request error
        if (response.StatusCode == HttpStatusCode.BadRequest)
        {
            try
            {
                requesterror = JsonConvert.DeserializeObject<RequestError>(content)!;
            }
            catch
            {
                throw new Exception($"ERROR INTERNO : {content}");
            }
            throw new ApplicationException(requesterror.ToString());
        }

        // intentar extraer el mensaje del error
        try
        {
            error = JsonConvert.DeserializeObject<Exception>(content)!;
        }
        catch { }

        if (error != null)
        {
            throw new Exception($"{status} \n\n {error.Message}");
        }

        throw new Exception($"ERROR INTERNO : {status}");

    }
}
