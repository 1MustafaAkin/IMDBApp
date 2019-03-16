using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Imdb.BLL.Abstract;
using Imdb.BLL.DependencyResolver.Ninject;
using Imdb.DAL;
using Imdb.DATA.Concrete;

namespace Imdb.App.Controllers
{
    public class MoviesSeriesController : Controller
    {

        public MoviesSeriesController()
        {
            _moviesSeriesService = InstanceFactory.GetInstance<IMoviesSeriesService>();
            _categoryService = InstanceFactory.GetInstance<ICategoryService>();
            _moviesSeriesCategoryService = InstanceFactory.GetInstance<IMoviesSeriesCategoryService>();
            moviesSeriesCategory = new MoviesSeriesCategory(); 
        }

        private IMoviesSeriesService _moviesSeriesService;
        private ICategoryService _categoryService;
        private IMoviesSeriesCategoryService _moviesSeriesCategoryService;
        MoviesSeriesCategory moviesSeriesCategory;

        // GET: MoviesSeries
        public ActionResult Index()
        {
            return View(_moviesSeriesService.GetAll());
        }

        // GET: MoviesSeries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MoviesSeries moviesSeries = _moviesSeriesService.GetMoviesSeriesById(id);
            if (moviesSeries == null)
            {
                return HttpNotFound();
            }
            return View(moviesSeries);
        }

        // GET: MoviesSeries/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(_categoryService.GetAll(), "CategoryID", "CategoryName");
            return View();
        }

        // POST: MoviesSeries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovieSeriesID,MovieSeriesName,Description,ReleaseDate,Duration,Trailer,Photos,IsSeries")] MoviesSeries moviesSeries, [Bind(Include = "CategoryID")] Categories categories)
        {
            if (ModelState.IsValid)
            {
                _moviesSeriesService.Add(moviesSeries);
                moviesSeriesCategory.CategoryID = categories.CategoryID;
                moviesSeriesCategory.MovieSeriesID = moviesSeries.MovieSeriesID;
                _moviesSeriesCategoryService.Add(moviesSeriesCategory);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(_categoryService.GetAll(), "CategoryID", "CategoryName");
            return View(moviesSeries);
        }

        // GET: MoviesSeries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MoviesSeries moviesSeries = _moviesSeriesService.GetMoviesSeriesById(id);
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
                _moviesSeriesService.Update(moviesSeries);
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
            MoviesSeries moviesSeries = _moviesSeriesService.GetMoviesSeriesById(id);
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
            try
            {   

                MoviesSeries moviesSeries = _moviesSeriesService.GetMoviesSeriesById(id);
                _moviesSeriesService.Delete(moviesSeries);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }

        public ActionResult ListOfMovies()
        {
            return View(_moviesSeriesService.GetMoviesSeriesByIsMovies());
        }

        public ActionResult ListOfSeries()
        {
            return View(_moviesSeriesService.GetMoviesSeriesByIsSeries());
        }

        public ActionResult MoviesSeriesDetails(int id)
        {
            return View(_moviesSeriesService.GetMoviesSeriesById(id));
        }

        public ActionResult AddCategoryToMoviesSeries(int id)
        {
            ViewBag.CategoryID = new SelectList(_categoryService.GetAll(), "CategoryID", "CategoryName");
            ViewBag.MovieSeriesID = new SelectList(_moviesSeriesService.GetMoviesSeriesListById(id), "MovieSeriesID", "MovieSeriesName");
            return View();
        }

        [HttpPost]
        public ActionResult AddCategoryToMoviesSeries([Bind(Include = "ID,MovieSeriesID,CategoryID")] MoviesSeriesCategory moviesSeriesCategory)
        {
            MoviesSeriesCategory DoesExistCategory = _moviesSeriesCategoryService.GetAll().FirstOrDefault(x => x.MovieSeriesID == moviesSeriesCategory.MovieSeriesID && x.CategoryID == moviesSeriesCategory.CategoryID);
            if (DoesExistCategory == null)
            {
                _moviesSeriesCategoryService.Add(moviesSeriesCategory);
                return RedirectToAction("Index");
            }
            else
            {
                Response.Write("<script language=javascript>alert('Bu kategori bu filme zaten atanmış');</script>");
            }

            ViewBag.CategoryID = new SelectList(_categoryService.GetAll(), "CategoryID", "CategoryName");
            ViewBag.MovieSeriesID = new SelectList(_moviesSeriesService.GetMoviesSeriesListById(moviesSeriesCategory.MovieSeriesID), "MovieSeriesID", "MovieSeriesName");
            return View();
        }


        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {   

        //        //db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
