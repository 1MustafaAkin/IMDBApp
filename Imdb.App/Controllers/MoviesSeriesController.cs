using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Imdb.DAL;
using Imdb.DATA.Concrete;

namespace Imdb.App.Controllers
{
    public class MoviesSeriesController : Controller
    {
        private Context db = new Context();

        // GET: MoviesSeries
        public ActionResult Index()
        {
            return View(db.MoviesSeries.ToList());
        }

        // GET: MoviesSeries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MoviesSeries moviesSeries = db.MoviesSeries.Find(id);
            if (moviesSeries == null)
            {
                return HttpNotFound();
            }
            return View(moviesSeries);
        }

        // GET: MoviesSeries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MoviesSeries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovieSeriesID,MovieSeriesName,Description,ReleaseDate,Duration,Trailer,Photos,IsSeries")] MoviesSeries moviesSeries)
        {
            if (ModelState.IsValid)
            {
                db.MoviesSeries.Add(moviesSeries);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(moviesSeries);
        }

        // GET: MoviesSeries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MoviesSeries moviesSeries = db.MoviesSeries.Find(id);
            if (moviesSeries == null)
            {
                return HttpNotFound();
            }
            return View(moviesSeries);
        }

        // POST: MoviesSeries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovieSeriesID,MovieSeriesName,Description,ReleaseDate,Duration,Trailer,Photos,IsSeries")] MoviesSeries moviesSeries)
        {
            if (ModelState.IsValid)
            {
                db.Entry(moviesSeries).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(moviesSeries);
        }

        // GET: MoviesSeries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MoviesSeries moviesSeries = db.MoviesSeries.Find(id);
            if (moviesSeries == null)
            {
                return HttpNotFound();
            }
            return View(moviesSeries);
        }

        // POST: MoviesSeries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MoviesSeries moviesSeries = db.MoviesSeries.Find(id);
            db.MoviesSeries.Remove(moviesSeries);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
