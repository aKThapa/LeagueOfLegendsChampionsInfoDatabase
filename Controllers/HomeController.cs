using DatabaseStuff.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatabaseStuff.Controllers
{
    public class HomeController : Controller
    {
        //Make a database connection
        private LeagueOfLegendsChampionsEntities db = new LeagueOfLegendsChampionsEntities();


        // GET: Home
        public ActionResult Index()
        {
            var movies = from m in db.Champions
                         select m;
            return View(movies);
        }

        public ActionResult Details(int? id)
        {
            Champion champion = db.Champions.Find(id);
            return View(champion);
        }

        public ActionResult Create()
        {
           return View();
        }

        [HttpPost]
        public ActionResult Create(Champion champion)
        {
            if (champion.ImageURL == null)
            {
                champion.ImageURL = "http://i.imgur.com/0cd0Xfk.jpg";
            }
            db.Champions.Add(champion);
            db.SaveChanges();
            //go back to index page
            return RedirectToAction("index");
        }

        public ActionResult Edit(int? id)
        {
            Champion champion = db.Champions.Find(id);
            return View(champion);
        }

        [HttpPost]
        public ActionResult Edit(Champion champion)
        {
            if (champion.ImageURL == null)
            {
                champion.ImageURL = "http://i.imgur.com/0cd0Xfk.jpg";
            }
            db.Entry(champion).State = EntityState.Modified;
            db.SaveChanges();
            //go back to index page
            return RedirectToAction("index");
            
        }

        public ActionResult Delete(int? id)
        {
            Champion champion = db.Champions.Find(id);
            return View(champion);
        }

        [HttpPost , ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Champion champion = db.Champions.Find(id);
            db.Champions.Remove(champion);
            db.SaveChanges();
            //go back to index page
            return RedirectToAction("index");
        }



    }
}