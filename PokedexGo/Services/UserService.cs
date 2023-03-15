using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PokedexGo.Helpers;
using PokedexGo.Models;
using PokedexGo.Settings;

namespace PokedexGo.Services;

public class UserService
{
    // TODO: NEW Skriv en tydlig kommentar om: Förbättring är att inte ha direkt kontakt med databasen från appen, utan ha en api

    private readonly IMongoCollection<User> _userCollection;

    public UserService()
    {
        var options = ServiceHelper.GetService<IOptions<UserDatabaseSettings>>();
        var mongoClient = new MongoClient(options.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(options.Value.DatabaseName);
        _userCollection = mongoDatabase.GetCollection<User>(options.Value.UserCollectionName);
    }

    public async Task<User> GetUserAsync(string userName, string password) =>
        await _userCollection.Find(x => x.UserName == userName && x.UserPassword == password).FirstOrDefaultAsync();

    public async Task CreateUserAsync(User user) =>
        await _userCollection.InsertOneAsync(user);

    public async Task UpdateUserAsync(User user, Pokemon pokemon)
    {
        user.Pokemon.Add(pokemon);
        await _userCollection.ReplaceOneAsync(x => x.Id == user.Id, user);
    }

    public async Task UpdateUserAsync(User user) =>
        await _userCollection.ReplaceOneAsync(x => x.Id == user.Id, user);
}
