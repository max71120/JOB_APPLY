using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCore.MongoDB.CRUD.Models
{
    public class Drone
    {
        [BsonId]

        public ObjectId Id { get; set; }
        public string DroneName { get; set; }
        public int FlyDuration { get; set; }
        public DateTime DateEvent { get; set; }
        public string ClientMail { get; set; }

    }
}