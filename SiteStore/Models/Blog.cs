using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using static System.Net.Mime.MediaTypeNames;

namespace SiteStore.Models
{
    [BsonIgnoreExtraElements]
    public class BlogPost : Father
    {

        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        //public ObjectId Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
        public string Text { get; set; }
        
        public string Author { get; set; }

        public DateTime CreatedDate { get; set; }
        //public DateTime PostDate { get; set; }

        public DateTime UpdatedDate { get; set;}

        public bool Published { get; set; }
    }
    public class Blog
    {
        public List<BlogPost> Posts { get; set;}

    }
}
