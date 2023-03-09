using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PokedexGo.Services;

public class HttpService
{
    private readonly HttpClient _client;
    //private readonly JsonSerializerOptions _jsonSerializerOptions;

    public HttpService()
    {
        _client = new HttpClient()
        {
            BaseAddress = new Uri("https://pokeapi.co/api/v2/")
        };
        // TODO: Eventuellt ha kvar för att visa läraren
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
