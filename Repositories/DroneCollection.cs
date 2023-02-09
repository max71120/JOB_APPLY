using MongoDB.Bson;
using MongoDB.Driver;
using MVCCore.MongoDB.CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCore.MongoDB.CRUD.Repositories
{

    public class DroneCollection : IDroneCollection
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<Drone> Collection;

        public DroneCollection()
        {
            Collection = _repository.db.GetCollection<Drone>("Drones");
        }

        public void DeleteDrone(String id)
        {
            var filter = Builders<Drone>.Filter.Eq(s => s.Id, new ObjectId(id));
Collection.DeleteOneAsync(filter);
        }

        public List<Drone> GetAllDrones()
        {

            var query = Collection.
                Find(new BsonDocument()).ToListAsync();

            return query.Result;
        }

        public Drone GetDronebyId(string id)
        {
            var drone = Collection.Find(
                new BsonDocument { { "_id", new ObjectId(id) } }).FirstAsync().Result;
            return drone;
        }

        public void InsertDrone(Drone drone)
        {
            Collection.InsertOneAsync(drone);
        }

        public void UpdateDrone(Drone drone)
        {
            var filter = Builders<Drone>
                .Filter
                 .Eq(s => s.Id, drone.Id);
            Collection.ReplaceOneAsync(filter, drone);
        }
    }
}