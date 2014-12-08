using S00126699_CA2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S00126699_CA2.Controllers
{
    public class HomeController : Controller
    {
        private MovieDb db = new MovieDb();

        public ActionResult Index()
        {
            #region Test
            /*List<Movie> TempStore = db.Movies.ToList();

            if (TempStore.Count != 0){
            return View(db.Movies.ToList());
            }
            else{
                return  RedirectToAction("Create");

            }*/
            #endregion

            return View(db.Movies.ToList());
        }

        public ActionResult Details(int id = 0)
        {
            Movie m = db.Movies.Find(id);
            if (m == null)
            {
                return HttpNotFound();

            }
            else
            {
            //HEY SHOW ME ACTORS
            m.Actors = (from e in db.Actors
                        where e.MovieID.Equals(id)
                        select e).ToList();
            }
            //m.Actors.Count();
            return View(m);
        }

        #region Create Movie

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        #endregion

        #region Edit Movie
        public ActionResult Edit(int id)
        {
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
               
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }
        #endregion

        #region Delete Movie

        public ActionResult Delete(int id)
        {
            Movie movie = db.Movies.Find(id);

          
            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion
    }
}
