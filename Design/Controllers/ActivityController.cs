using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Design.Controllers
{
    public class ActivityController : Controller
    {
        // GET: Activity
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IEnumerable<Activity> GetValues()
        {
            using (DesignEntities entity = new DesignEntities())
            {
                return entity.Activities.ToList();
            }

        }
        [HttpPost]
        public void PostData(Activity activity)
        {
            using (DesignEntities entity = new DesignEntities())
            {
                entity.Activities.Add(activity);
                entity.SaveChanges();
            }
        }

        [HttpPut]
        public void Put(int id,int ActivityId)
        {
            using (DesignEntities entity = new DesignEntities())
            {
                IEnumerable<Activity> activityList = entity.Activities.ToList();
                foreach (Activity activity in activityList)
                {
                    if (activity.activityID == ActivityId)
                    {
                        if (id == 1)
                            activity.IsSaved = true;
                        if (id == 2)
                        {
                            if (activity.IsBooked == true)
                            {
                                // error already booked
                                activity.IsBooked = false;
                            }
                            else
                            {
                                activity.IsBooked = true;
                            }
                        }
                    }
                }
                entity.SaveChanges();
            }

        }


    }


}