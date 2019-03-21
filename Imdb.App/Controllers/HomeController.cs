using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Imdb.BLL.Abstract;
using Imdb.BLL.Concrete;
using Imdb.BLL.DependencyResolver.Ninject;
using Imdb.DAL;
using Imdb.DATA.Concrete;

namespace Imdb.App.Controllers
{
    public class HomeController : Controller
    {
        Context db = new Context();

        public HomeController()
        {
            _moviesSeriesService = InstanceFactory.GetInstance<IMoviesSeriesService>();
            _ratingService = InstanceFactory.GetInstance<IRatingService>();
        }

        private IMoviesSeriesService _moviesSeriesService;
        private IRatingService _ratingService;

        // GET: Home
        public ActionResult Index()
        {   
            //int score = 0;
            //decimal averageImdb;
            //int ratingCount = 0;
            //List<MoviesSeries> movies;


            //foreach (var movie in _moviesSeriesService.GetAll())
            //{
            //    ratingCount = _ratingService.GetRatingByMoviesID(movie.MovieSeriesID).Count();
            //    foreach (var item in _ratingService.GetRatingByMoviesID(movie.MovieSeriesID))
            //    {
            //        score += item.Score;
            //    }
            //    averageImdb = (decimal)score / ratingCount;
            //    movies.Add(averageImdb);
            //}
            
            
            //ViewBag.AllRating = Decimal.Round(averageImdb, 1);
            return View(_moviesSeriesService.GetAll());
        }

        // GET: Home/Details/5
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
