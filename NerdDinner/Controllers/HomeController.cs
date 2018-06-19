using NerdDinner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace NerdDinner.Controllers
{
    public class HomeController : Controller
    {
        NerdDinners nerdDinners = new NerdDinners();
        DinnerRepository repo = new DinnerRepository();
        public ActionResult Index()
        {
            var dinners = repo.FindAllDinners();
            return View(dinners);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Details(int id)
        {
            Dinner dinner = repo.GetDinner(id);
            if (dinner == null)
                return View("Not Found");
            else
                return View(dinner);
        }
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            Dinner dinner = repo.GetDinner(id);
            return View(dinner);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(Dinner dinner)
        {
            if(ModelState.IsValid)
            {
                nerdDinners.Entry(dinner).State = System.Data.Entity.EntityState.Modified;
                nerdDinners.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dinner);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Create(Dinner dinner)
        {
            if(ModelState.IsValid)
            {
                repo.Add(dinner);
                repo.Save();
                return RedirectToAction("Index");
            }
            return View(dinner);
        }

        public ActionResult Delete(int id)
        {
            Dinner dinner = repo.GetDinner(id);
            if (dinner == null)
            {
                return HttpNotFound();
            }
            return View(dinner);
        }

     
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dinner dinner = repo.GetDinner(id);
            repo.Delete(dinner);
            repo.Save();
            return RedirectToAction("Index");
        }
    }
}