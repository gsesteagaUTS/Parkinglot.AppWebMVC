using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Parkinglot.AppWebMVC.Domain
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private set; }
        public string FullName { get; private set; }
        public int ControlNumber { get; private set; }
        public List<AccessControl> AccessControls { get; private set; }

    
        public User()
        {
        }

        public User(string fullName, int controlNumber)
        {
            FullName = fullName;
            ControlNumber = controlNumber;
        }

        public User(string id, string fullName, int controlNumber, List<AccessControl> accessControls)
        {
            Id = id;
            FullName = fullName;
            ControlNumber = controlNumber;
            AccessControls = accessControls;
        }
    }
}
