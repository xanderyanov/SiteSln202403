using MongoDB.Bson;
using MongoDB.Driver;
using SiteStore.Models;

namespace SiteStore;

public class Domain
{

    public List<BlogPost> ExistingPosts;


}

public static class Data
{
    public static IMongoDatabase DB;

    public static Domain MainDomain;

    public static IMongoCollection<BlogPost> blogCollection;

    


    public static void InitData(IConfiguration Configuration)
    {
        var dbConfigSection = Configuration.GetSection("DBConfig");
        var dbConfig = new DBConf(dbConfigSection);
        var mongoClient = new MongoClient(dbConfig.ConnectionString);
        DB = mongoClient.GetDatabase(dbConfig.DBName);

        LoadObjects();
    }

    public static void LoadObjects()
    {
        Domain domain = new Domain();

        //Каталог и все такое

        blogCollection = DB.GetCollection<BlogPost>("blogpost");
        domain.ExistingPosts = GetAllPosts();

        MainDomain = domain;
    }

    private static List<BlogPost> GetAllPosts()
    {
        BsonDocument filter = new BsonDocument();
        return blogCollection.Find(filter).ToList();
    }


}