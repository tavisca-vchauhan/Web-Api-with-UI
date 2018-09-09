using System;
using DataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Design.Controllers
{
    public class HotelController : Controller
    {
        // GET: Hotel
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IEnumerable<Hotel> GetValues()
        {
            using (DesignEntities entity = new DesignEntities())
            {
                return entity.Hotels.ToList();
            }

        }
        [HttpPost]
        public void PostData(Hotel hotel)
        {
            using (DesignEntities entity = new DesignEntities())
            {
                entity.Hotels.Add(hotel);
                entity.SaveChanges();
            }
        }

        [HttpPut]
        public void Put(int id, int HotelId)
        {
            using (DesignEntities entity = new DesignEntities())
            {
                IEnumerable<Hotel> hotelList = entity.Hotels.ToList();
                foreach (Hotel hotel in hotelList)
                {
                    if (hotel.hotelId == HotelId)
                    {
                        if (id == 1)
                            hotel.IsSaved = true;
                        if (id == 2)
                        {
                            if (hotel.IsBooked == true)
                            {
                                // error already booked
                                hotel.IsBooked = false;
                            }
                            else
                            {
                                hotel.IsBooked = true;
                            }
                        }
                    }
                }
                entity.SaveChanges();
            }

        }
    }
}