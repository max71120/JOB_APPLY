using MVCCore.MongoDB.CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCCore.MongoDB.CRUD.Repositories
{
   public interface IDroneCollection
    {
        void InsertDrone(Drone drone);
        void UpdateDrone(Drone drone);
        void DeleteDrone(string id);
        List<Drone> GetAllDrones();
        Drone GetDronebyId(string id);

    }
}
