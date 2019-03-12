using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Imdb.BLL.Abstract;
using Imdb.BLL.DependencyResolver.Ninject;
using Imdb.DAL;
using Imdb.DATA.Concrete;

namespace Imdb.App.Controllers
{
    public class SeasonsController : Controller
    {
        ISeasonService _seasonService;
        IMoviesSeriesService _moviesSeriesService;

        public SeasonsController()
        {
            _seasonService = InstanceFactory.GetInstance<ISeasonService>();
            _moviesSeriesService = InstanceFactory.GetInstance<IMoviesSeriesService>();
        }

        // GET: Seasons
        public ActionResult Index()
        {
            var season = _seasonService.GetAllWithInclude("MoviesSeries");
            return View(season);
        }

        // GET: Seasons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Season season = _seasonService.GetAllWithIncludeById(id, "MoviesSeries");
            if (season == null)
            {
                return HttpNotFound();
            }
            return View(season);
        }

        // GET: Seasons/Create
        public ActionResult Create()
        {
            ViewBag.MoviesSeriesID = new SelectList(_moviesSeriesService.GetMoviesSeriesByIsSeries(), "MovieSeriesID", "MovieSeriesName");
            return View();
        }

        // POST: Seasons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SeasonID,SeasonNo,Episode,MoviesSeriesID")] Season season)
        {
            if (ModelState.IsValid)
            {
                _seasonService.Add(season);
                return RedirectToAction("Index");
            }

            ViewBag.MoviesSeriesID = new SelectList(_moviesSeriesService.GetAll(), "MovieSeriesID", "MovieSeriesName", season.MoviesSeriesID);
            return View(season);
        }

        // GET: Seasons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Season season = _seasonService.GetSeasonById(id);
            if (season == null)
            {
                return HttpNotFound();
            }
            ViewBag.MoviesSeriesID = new SelectList(_moviesSeriesService.GetMoviesSeriesByIsSeries(), "MovieSeriesID", "MovieSeriesName", season.MoviesSeriesID);
            return View(season);
        }

        // POST: Seasons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SeasonID,SeasonNo,Episode,MoviesSeriesID")] Season season)
        {
            if (ModelState.IsValid)
            {
                _seasonService.Update(season);
                return RedirectToAction("Index");
            }
            ViewBag.MoviesSeriesID = new SelectList(_moviesSeriesService.GetAll(), "MovieSeriesID", "MovieSeriesName", season.MoviesSeriesID);
            return View(season);
        }

        // GET: Seasons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Season season = _seasonService.GetAllWithIncludeById(id, "MoviesSeries");
            if (season == null)
            {
                return HttpNotFound();
            }
            return View(season);
        }

        // POST: Seasons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Season season = _seasonService.GetSeasonById(id);
            _seasonService.Delete(season);
            return RedirectToAction("Index");
        }

    }
}
