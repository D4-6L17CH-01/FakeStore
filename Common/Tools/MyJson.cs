using Newtonsoft.Json;
using System.Text;

namespace Common.Tools;
public class MyJson
{
    public class JsonStringContent : StringContent
    {
        public JsonStringContent(object obj) : base(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json") { }
    }

    public static string SerializeObject(object o) => JsonConvert.SerializeObject(o);

    public static async Task<T> ToObjectAsync<T>(string value)
    {
        return await Task.Run(() =>
        {
            return JsonConvert.DeserializeObject<T>(value);
        });
    }

    public static async Task<string> StringifyAsync(object value)
    {
        return await Task.Run(() =>
        {
            return JsonConvert.SerializeObject(value);
        });
    }

    //Metodo para el manejo del formato JSONL
    public static async Task<List<T>> ToObjectJsonlAsync<T>(string value)
    {
        var jsonl = value.Split('\n');
        List<T> vals = new List<T>();
        return await Task.Run(() =>
        {
            foreach (var line in jsonl) vals.Add(JsonConvert.DeserializeObject<T>(line));
            return vals;
        });
    }

    //Metodo para el manejo del formato JSONL
    public static async Task<string> StringifyJsonlAsync(List<object> value)
    {
        var jsonl = "";
        return await Task.Run(() =>
        {
            foreach (var o in value)
            {
                jsonl = $"{jsonl}{JsonConvert.SerializeObject(o)}\n";
            }
            return jsonl;
        });
    }
}