using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PokedexGo.Services;

public class HttpService
{
    public HttpClient Client { get; set; }
    private readonly HttpClient _client;
    //private readonly JsonSerializerOptions _jsonSerializerOptions;

    public HttpService()
    {
        Client = new HttpClient()
        {
            BaseAddress = new Uri("https://pokeapi.co/api/v2/")
        };
        //_jsonSerializerOptions = new JsonSerializerOptions
        //{
        //    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        //    WriteIndented = true
        //};
    }

    public async Task<T> HttpRequest<T>(string requestUri)
    {
        var response = await _client.GetAsync(requestUri);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(content);
    }
}
