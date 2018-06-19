using NerdDinner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NerdDinner.Controllers
{
    public class RSVPController : Controller
    {
        DinnerRepository repo = new DinnerRepository();

        [Authorize]
        // GET: RSVP
        public ActionResult Register(int id)
        {
            Dinner dinner = repo.GetDinner(id);
            if(!dinner.IsUserRegistered(User.Identity.Name))
            {
                RSVP rsvp = new RSVP
                {
                    AttendeeName = User.Identity.Name
                };
                dinner.RSVPs.Add(rsvp);
                repo.Save();
            }
            return Content("Thanks - we'll see you there!");
        }
    }
}