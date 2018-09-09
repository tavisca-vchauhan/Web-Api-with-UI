using System;
using DataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Design.Controllers
{
    public class AirController : Controller
    {
        // GET: Air
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IEnumerable<Air> GetValues()
        {
            using (DesignEntities entity = new DesignEntities())
            {
                return entity.Airs.ToList();
            }

        }
        [HttpPost]
        public void PostData(Air air)
        {
            using (DesignEntities entity = new DesignEntities())
            {
                entity.Airs.Add(air);
                entity.SaveChanges();
            }
        }

        [HttpPut]
        public void Put(int id, int AirId)
        {
            using (DesignEntities entity = new DesignEntities())
            {
                IEnumerable<Air> airList = entity.Airs.ToList();
                foreach (Air air in airList)
                {
                    if (air.airId == AirId)
                    {
                        if (id == 1)
                            air.IsSaved = true;
                        if (id == 2)
                        {
                            if (air.IsBooked == true)
                            {
                                // error already booked
                                air.IsBooked = false;
                            }
                            else
                            {
                                air.IsBooked = true;
                            }
                        }
                    }
                }
                entity.SaveChanges();
            }

        }
    }
}