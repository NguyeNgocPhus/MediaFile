using Benchmark.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Benchmark.Services;

public class BadHttpClient
{
    private static readonly HttpClient client = new HttpClient();
    private const string BaseAddress = "http://localhost:5000";

    public BadHttpClient()
    {
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<List<Message>> GetMessageCassandra()
    {
        return await client.GetFromJsonAsync<List<Message>>($"{BaseAddress}/Message/Test1");
    }
}
