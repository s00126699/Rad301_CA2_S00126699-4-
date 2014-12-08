using S00126699_CA2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S00126699_CA2.Controllers
{
    public class ActorController : Controller
    {
        private MovieDb db = new MovieDb();
        //
        // GET: /Actor/

        public ActionResult Index()
        {
            return View(db.Actors.ToList());
        }

        //
        // GET: /Actor/Details/5

        public ActionResult Details(int id)
        { 
            Actor act = db.Actors.Find(id);
            if (act == null)
            {
                return HttpNotFound();
            }
            
            return View(act);
        }

        //
        // GET: /Actor/Create

        public ActionResult Create(int movieID)
        {
            Actor add = new Actor { MovieID = movieID };
            return View();
        }

        //
        // POST: /Actor/Create

        [HttpPost]
        public ActionResult Create(Actor actor, int movieID)
        {
            actor.MovieID = movieID;
            if (ModelState.IsValid)
            {
                db.Actors.Add(actor);
                db.SaveChanges();
                return RedirectToAction("Details", "Home", new { id = actor.MovieID });
            }
            return View(actor);
        }

        //
        // GET: /Actor/Edit/5

        //public ActionResult Edit(int id)
        //{
        //    Actor actor = db.Actors.Find(id);

        //    return View(actor);
        //}

        ////
        //// POST: /Actor/Edit/5

        //[HttpPost]
        //public ActionResult Edit(Actor actor, int movieID)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        actor.MovieID = movieID;
        //        db.Entry(actor).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(actor);
        //}

        #region Delete Actor

        public ActionResult Delete(int id = 0)
        {
            Actor actor = db.Actors.Find(id);
          
            return View(actor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Actor actor = db.Actors.Find(id);
            db.Actors.Remove(actor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion

    }
}
