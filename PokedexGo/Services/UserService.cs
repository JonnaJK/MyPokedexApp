using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PokedexGo.Helpers;
using PokedexGo.Models;
using PokedexGo.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexGo.Services;

public class UserService
{
    private readonly IMongoCollection<User> _users;
    // förbättring är att inte ha direkt kontakt med databasen från appen, utan ha en api
    public UserService()
    {
        var options = ServiceHelper.GetService<IOptions<UserDatabaseSettings>>();
        var mongoClient = new MongoClient(options.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(options.Value.DatabaseName);
        _users = mongoDatabase.GetCollection<User>(options.Value.UserCollectionName);
    }

    public async Task<User> GetUserAsync(string userName, string password)
    {
        return await _users.Find(x => x.UserName == userName && x.UserPassword == password).FirstOrDefaultAsync();
    }

    public async Task CreateUserAsync(User user) =>
        await _users.InsertOneAsync(user);

    public async Task UpdateUserAsync(User user, Pokemon pokemon)
    {
        user.Pokemons.Add(pokemon);
        await _users.ReplaceOneAsync(x => x.Id == user.Id, user);
    }

    //public static async Task<IMongoCollection<T>> GetUserCollectionFromDB<T>()
    //{
    //    // TODO: Not done
    //    var settings = MongoClientSettings.FromConnectionString("mongodb+srv://Jonna:wKH2nq6pa3X6oM6ED6VC@myfirstcluster.tq5osnl.mongodb.net/?retryWrites=true&w=majority");
    // Kanske behöver settings!?
    //    settings.ServerApi = new ServerApi(ServerApiVersion.V1);
    //    var client = new MongoClient(settings);
    //    var database = client.GetDatabase("PokedexGo");
    //    return await database.GetCollection<T>("User");
    //    //var myCollection = database.GetCollection<T>("User");
    //    //return myCollection;
    //}
}
