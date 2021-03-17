using System.IO.Compression;
using System;
using System.Collections.Generic;
using MongoDB.Driver;
using Parkinglot.AppWebMVC.Domain;
using MongoDB.Bson;

namespace Parkinglot.AppWebMVC.Repositories
{
    public interface IUserRepository
    {
        User AddUser(User user);
        //DeleteUser
        //UpdateUser
        User FindUser(int controlNumber);
        //FindAllUsers
        AccessControl AddAccesControl(AccessControl accessControl);
        List<AccessControl> FindAccesControlsByUser(string userId);
        List<AccessControl> FindAllAccesControls();

    }
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> usersCollection;
        public UserRepository(IMongoDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            usersCollection = database.GetCollection<User>(settings.UserCollection);
        }
        public AccessControl AddAccesControl(AccessControl accessControl)
        {
            var user = usersCollection.Find(x => x.Id == accessControl.UserId).FirstOrDefault();
            if (user != null)
            {
                user.AccessControls.Add(accessControl);
                usersCollection.FindOneAndReplace(x => x.Id == accessControl.UserId, user);

            }
            throw new NotImplementedException();
        }

        public User AddUser(User user)
        {
            usersCollection.InsertOne(user);
            return user;
        }

        public List<AccessControl> FindAccesControlsByUser(string userId)
        {
            var collection = usersCollection.Find(x => x.Id == userId);
            var user = collection.FirstOrDefault();
            return user.AccessControls;
        }

        public List<AccessControl> FindAllAccesControls()
        {
            // Builders<User>.Filter.All(new ProjectionDefinitionBuilder<User>().Include(x=> x.AccessControls));
            // var accessCotrols = usersCollection.Find(x=> true).Project(new ProjectionDefinitionBuilder<User>().Include(x=> x.AccessControls)).ToList();

            var result = new List<AccessControl>();
            // foreach (var ac in accessCotrols){
            //     ac.GetElement()
            // }
            //     result.AddRange();

            var docs = usersCollection.Find(x=> true).Project(x => x.AccessControls).ToList();
            foreach (var ac in docs)
            {
                result.AddRange(ac);
            }
            return result;

        }

        public User FindUser(int controlNumber)
        {
            throw new NotImplementedException();
        }
    }
}
