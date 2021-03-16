using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Parkinglot.AppWebMVC.Domain
{
    public class Parkinglot
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private set; }
        public string Name { get; private set; }
        public SecurityBooth SecurityBooth { get; private set; }

        public Parkinglot()
        {
            
        }

        public Parkinglot(string name, SecurityBooth securityBooth)
        {
            Name = name;
            SecurityBooth = securityBooth;
        }

        public Parkinglot(string id, string name, SecurityBooth securityBooth)
        {
            Id = id;
            Name = name;
            SecurityBooth = securityBooth;
        }
    }
}
