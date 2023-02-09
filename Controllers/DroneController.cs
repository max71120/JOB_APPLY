using MongoDB.Bson;
using MVCCore.MongoDB.CRUD.Models;
using MVCCore.MongoDB.CRUD.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCore.MongoDB.CRUD.Controllers
{
    public class DroneController : Controller
    {
        private IDroneCollection db = new DroneCollection();
        // GET: Drone
        public ActionResult Index()
        {
            var drones = db.GetAllDrones();
            return View(drones);
        }

        // GET: Drone/Details/5
        public ActionResult Details(string id)
        {
            var drone = db.GetDronebyId(id);
            return View(drone);
        }

        // GET: Drone/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Drone/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var drone = new Drone()

                {
                    DroneName = collection["DroneName"],
                    FlyDuration = int.Parse(collection["FlyDuration"]),
                    DateEvent = DateTime.Parse(collection["DateEvent"]),
                    ClientMail = collection["ClientMail"]
                };

                db.InsertDrone(drone);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Drone/Edit/5
        public ActionResult Edit(string id)
        {
            var drone = db.GetDronebyId(id);
            return View();
        }

        // POST: Drone/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                var drone = new Drone()

                {
                    Id = new ObjectId(id),
                    DroneName = collection["DroneName"],
                    FlyDuration = int.Parse(collection["FlyDuration"]),
                    DateEvent = DateTime.Parse(collection["DateEvent"]),
                    ClientMail = collection["ClientMail"]
                };

                db.UpdateDrone(drone);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Drone/Delete/5
        public ActionResult Delete(string id)
        {
            var drone = db.GetDronebyId(id);
            return View(drone);
        }

        // POST: Drone/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                db.DeleteDrone(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }

    internal class drones
    {
        public drones()
        {
        }

        public string DroneName { get; set; }
        public string FlyDuration { get; set; }
        public string DateEvent { get; set; }

        public string ClientMail { get; set; }
    }
}
