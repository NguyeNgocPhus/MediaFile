using System.Net.Http.Headers;
using System.Net.Http.Json;
using Benchmark.Models;

namespace Benchmark.Services;

public class GoodHttpClient
{
    private static readonly HttpClient client = new HttpClient();
    private const string BaseAddress = "http://localhost:5000";

    public GoodHttpClient()
    {
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<List<Message>> GetMessagePsg()
    {
        return await client.GetFromJsonAsync<List<Message>>($"{BaseAddress}/Message/Test2");
    }

}
