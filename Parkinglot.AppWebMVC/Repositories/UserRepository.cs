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
            throw new NotImplementedException();
            
        }

        public User FindUser(int controlNumber)
        {
            var user = usersCollection.Find(x=> x.ControlNumber == controlNumber).FirstOrDefault();
            return user;
        }
    }
}
