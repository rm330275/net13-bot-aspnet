using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;

namespace SimpleBot
{
    public class SimpleBotUser
    {
        private static object col;
        private static object _dictProfiles;

        public static string Reply(Message message)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var doc = new BsonDocument()
            {
                {"id",message.Id },
                {"texto",message.Text },
                {"app","teste" }
            };

            //var id = message.Id;
            //var profile = GetProfile(id);
            //profile.Visitas += 1;
            //SetProfile(id, profile);

            var db = client.GetDatabase("db01");
            var col = db.GetCollection<BsonDocument>("tabela01");
            col.InsertOne(doc);

            return $"{message.User} disse '{message.Text} ' ";
        }

        //public static UserProfile GetProfile(string id)
        //{
        //    _dictProfiles.TryGetValue(id,out var profile);

        //    if (profile == null)
        //    {
        //        return new UserProfile()
        //        {
        //            Id = id,
        //            Visitas = 0
        //        };
        //    }


        //    return null;
        //}

        //public static void SetProfile(string id, UserProfile profile)
        //{
        //    _dictProfiles[id] 
        //}
    }
}