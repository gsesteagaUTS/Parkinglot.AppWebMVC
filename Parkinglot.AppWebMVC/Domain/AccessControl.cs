using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Parkinglot.AppWebMVC.Domain
{
    public class AccessControl
    {
        // [BsonId]
        // [BsonRepresentation(BsonType.ObjectId)]
        // public string Id { get; private set; }
        public DateTime FullDate { get; private set; }
        [BsonIgnore]
        public User User { get; private set; }
        public string UserId { get; private set; }

        public AccessType AccessType { get; private set; }

        public AccessControl()
        {

        }
        public AccessControl(DateTime fullDate, string userId, AccessType accessType)
        {
            FullDate = fullDate;
            UserId = userId;
            AccessType = accessType;
        }
        public AccessControl(DateTime fullDate, User user, string userId, AccessType accessType)
        {
            FullDate = fullDate;
            User = user;
            UserId = userId;
            AccessType = accessType;
        }

        // public AccessControl(DateTime fullDate, User user, string userId, AccessType accessType)
        // {
        //     FullDate = fullDate;
        //     User = user;
        //     UserId = userId;
        //     AccessType = accessType;
        // }
    }
}

// {
//     "Id:":2asdasd",
//     ...,
//     "AccessControl": [
//         {
//             "Id":"",
//             "FullDate":"",
//             "UserId": ""
//         }
//     ]
// }
