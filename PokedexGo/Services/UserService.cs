using MongoDB.Driver;
using PokedexGo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexGo.Services;

public class UserService
{
    // förbättring är att inte ha direkt kontakt med databasen från appen, utan ha en api
    public UserService()
    {

    }

    public static IMongoCollection<T> GetUserCollectionFromDB<T>()
    {
        // TODO: Not done
        var settings = MongoClientSettings.FromConnectionString("mongodb+srv://Jonna:wKH2nq6pa3X6oM6ED6VC@myfirstcluster.tq5osnl.mongodb.net/?retryWrites=true&w=majority");
        settings.ServerApi = new ServerApi(ServerApiVersion.V1);
        var client = new MongoClient(settings);
        var database = client.GetDatabase("PokedexGo");
        return database.GetCollection<T>("User");
        //var myCollection = database.GetCollection<T>("User");
        //return myCollection;
    }

    public static async Task AddPokemonToUser(User user, Pokemon pokemon)
    {
        var userCollection = GetUserCollectionFromDB<User>();
        //var user = userCollection.AsQueryable().Where(x => x.Id == userId).FirstOrDefault();
        user.Pokemons.Add(pokemon);
        await userCollection.ReplaceOneAsync(x => x.Id == user.Id, user);
    }

    public static async Task SaveUser(User user)
    {
        user.Pokemons = new()
        {
            new Pokemon()
            {
                Name = "pikachu"
            }
        };
        // använda facade design pattern? För login!
        //var collection = GetUsersFromDB<User>().InsertOneAsync(user);
        var collection = GetUserCollectionFromDB<User>();
        await collection.InsertOneAsync(user);
    }

    public static User GetUser(string name, string password)
    {
        //return GetUsersFromDB<User>()
        //    .AsQueryable()
        //    .Where(x => x.UserName.ToLower().Contains(name.ToLower()) && x.UserPassword.Equals(password))
        //    .FirstOrDefault();
        var collection = GetUserCollectionFromDB<User>();
        var user = collection
            .AsQueryable()
            .Where(x => x.UserName.ToLower().Contains(name.ToLower()) && x.UserPassword.Equals(password))
            .FirstOrDefault();
        return user;
    }
}
