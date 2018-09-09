using System;
using DataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Design.Controllers
{
    public class CarController : Controller
    {
        // GET: Car
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IEnumerable<Car> GetValues()
        {
            using (DesignEntities entity = new DesignEntities())
            {
                return entity.Cars.ToList();
            }

        }
        [HttpPost]
        public void PostData(Car car)
        {
            using (DesignEntities entity = new DesignEntities())
            {
                entity.Cars.Add(car);
                entity.SaveChanges();
            }
        }

        [HttpPut]
        public void Put(int id, int CarId)
        {
            using (DesignEntities entity = new DesignEntities())
            {
                IEnumerable<Car> carList = entity.Cars.ToList();
                foreach (Car car in carList)
                {
                    if (car.carId == CarId)
                    {
                        if (id == 1)
                            car.IsSaved = true;
                        if (id == 2)
                        {
                            if (car.IsBooked == true)
                            {
                                // error already booked
                                car.IsBooked = false;
                            }
                            else
                            {
                                car.IsBooked = true;
                            }
                        }
                    }
                }
                entity.SaveChanges();
            }

        }
    }
}