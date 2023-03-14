using System.Text.Json;

namespace PokedexGo.Services;

public class HttpService
{
    private const string BASE_ADDRESS = "https://pokeapi.co/api/v2/";
    private readonly HttpClient _client;
    //private readonly JsonSerializerOptions _jsonSerializerOptions;

    public HttpService()
    {
        _client = new HttpClient()
        {
            BaseAddress = new Uri(BASE_ADDRESS)
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

    public async Task<T> HttpRequest<T>(Uri requestUri)
    {
        var request = requestUri.ToString().Replace(BASE_ADDRESS, string.Empty);
        return await HttpRequest<T>(request);
    }
}
