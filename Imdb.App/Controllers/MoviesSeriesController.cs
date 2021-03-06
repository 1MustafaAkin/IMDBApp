﻿using System;
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
using Microsoft.AspNet.Identity;
using PagedList;

namespace Imdb.App.Controllers
{
    public class MoviesSeriesController : Controller
    {

        public MoviesSeriesController()
        {
            _moviesSeriesService = InstanceFactory.GetInstance<IMoviesSeriesService>();
            _categoryService = InstanceFactory.GetInstance<ICategoryService>();
            _userService = InstanceFactory.GetInstance<IUserService>();
            _employeeService = InstanceFactory.GetInstance<IEmployeeService>();
            _moviesSeriesCategoryService = InstanceFactory.GetInstance<IMoviesSeriesCategoryService>();
            _moviesSeriesEmployeeService = InstanceFactory.GetInstance<IMoviesSeriesEmployeeService>();
            _moviesSeriesWatchListService = InstanceFactory.GetInstance<IMoviesSeriesWatchListService>();
            _ratingService = InstanceFactory.GetInstance<IRatingService>();
            _applicationUserService = InstanceFactory.GetInstance<IApplicationUserService>();
            moviesSeriesCategory = new MoviesSeriesCategory();
        }

        private IMoviesSeriesService _moviesSeriesService;
        private IUserService _userService;
        private ICategoryService _categoryService;
        private IEmployeeService _employeeService;
        private IMoviesSeriesCategoryService _moviesSeriesCategoryService;
        private IMoviesSeriesEmployeeService _moviesSeriesEmployeeService;
        private IMoviesSeriesWatchListService _moviesSeriesWatchListService;
        private IRatingService _ratingService;
        private IApplicationUserService _applicationUserService;
        MoviesSeriesCategory moviesSeriesCategory;


        public ActionResult Index()
        {
            return View(_moviesSeriesService.GetAll());
        }

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

        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(_categoryService.GetAll(), "CategoryID", "CategoryName");
            return View();
        }

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

        public ActionResult ListOfMovies(string sortOrder, int? page)
        {
            if (sortOrder == null)
                sortOrder = "nameDesc";
            ViewBag.CurrentSort = sortOrder;

            //ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            //ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc": "Date";

            //if (searchString != null)
            //{
            //    page = 1;
            //}
            //else
            //{
            //    searchString = currentFilter;
            //}

            //ViewBag.CurrentFilter = searchString;
            var movies = _moviesSeriesService.GetMoviesSeriesByIsMovies().OrderByDescending(x => x.MovieSeriesName);
            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    movies = movies.Where(s => s.MovieSeriesName.Contains(searchString));

            //}
            switch (sortOrder)
            {
                case "nameDesc":
                    movies = _moviesSeriesService.GetMoviesSeriesByIsMovies().OrderByDescending(x => x.MovieSeriesName);
                    break;
                case "nameAsc":
                    movies = _moviesSeriesService.GetMoviesSeriesByIsMovies().OrderBy(x => x.MovieSeriesName);
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(movies.ToPagedList(pageNumber, pageSize));
        }
    

        public ActionResult ListOfSeries()
        {
            return View(_moviesSeriesService.GetMoviesSeriesByIsSeries());
        }

        List<Employee> employees;
        int count = 0;
        public ActionResult MoviesSeriesDetails(int id)
        {
            User user = _userService.GetUsersByUserName(User.Identity.GetUserName());
            List<MoviesSeriesEmployee> employeesOfMoviesSeries = _moviesSeriesEmployeeService.GetEmployeeByMoviesSeriesId(id);
            
            MoviesSeries moviesSeries = _moviesSeriesService.GetMoviesSeriesById(id);

            if(user != null)
            {
                List<MoviesSeriesWatchList> moviesSeriesWatchList = _moviesSeriesWatchListService.GetMoviesSeriesWatchListByWatchList(user.UserID);
                Rating rating = _ratingService.GetScoreByUserAndMovie(user.UserID, id);
                ViewBag.rating = rating;
                ViewBag.comment = _ratingService.GetCommentByUserAndMovie(user.UserID, id);
                count = moviesSeriesWatchList.Where(x => x.MoviesSeriesID == id).ToList().Count();
            }

            ViewBag.AllComment = _ratingService.GetCommentByUserAndMovieWithInclude(id, "User", "RatingOfMovieSeries");

            int score=0;
            decimal averageImdb;
            int ratingCount = _ratingService.GetRatingByMoviesID(id).Count();
            foreach (var item in _ratingService.GetRatingByMoviesID(id))
            {
                score += item.Score;
            }
            if(ratingCount > 0 && score >0)
            {
                averageImdb = (decimal)score / ratingCount;
            }
            else
            {
                averageImdb = 0;
            }
           
            moviesSeries.AverageRating = Decimal.Round(averageImdb,1);

            
            if (count != 0)
                ViewBag.DoesExistMovieInWatchList = true;
            else
                ViewBag.DoesExistMovieInWatchList = false;

            employees = new List<Employee>();
            foreach (var item in employeesOfMoviesSeries)
            {
                employees.Add(_employeeService.GetEmployeeById(item.EmployeeID));
            }
            ViewBag.EmployeeOfMoviesSeries = employees;

            _moviesSeriesService.Update(moviesSeries);
            
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

        public ActionResult AddEmployeeToMoviesSeries(int id)
        {
            ViewBag.EmployeeID = new SelectList(_employeeService.GetAll(), "EmployeeID", "FirstName");
            ViewBag.MovieSeriesID = new SelectList(_moviesSeriesService.GetMoviesSeriesListById(id), "MovieSeriesID", "MovieSeriesName");
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployeeToMoviesSeries([Bind(Include = "MovieSeriesID,EmployeeID")] MoviesSeriesEmployee moviesSeriesEmployee)
        {
            MoviesSeriesEmployee DoesExistEmployee = _moviesSeriesEmployeeService.GetAll().FirstOrDefault(x => x.MovieSeriesID == moviesSeriesEmployee.MovieSeriesID && x.EmployeeID == moviesSeriesEmployee.EmployeeID);
            if (DoesExistEmployee == null)
            {
                _moviesSeriesEmployeeService.Add(moviesSeriesEmployee);
                return RedirectToAction("Index");
            }
            else
            {
                Response.Write("<script language=javascript>alert('Bu kategori bu filme zaten atanmış');</script>");
            }

            ViewBag.EmployeeID = new SelectList(_employeeService.GetAll(), "EmployeeID", "FirstName");
            ViewBag.MovieSeriesID = new SelectList(_moviesSeriesService.GetMoviesSeriesListById(moviesSeriesEmployee.MovieSeriesID), "MovieSeriesID", "MovieSeriesName");
            return View();
        }

        public ActionResult AddWatchList(int id)
        {
            MoviesSeriesWatchList moviesSeriesWatchList = new MoviesSeriesWatchList();
            User user = _userService.GetUsersByUserName(User.Identity.GetUserName());
            moviesSeriesWatchList.MoviesSeriesID = id;
            moviesSeriesWatchList.WatchListID = user.UserID;
            _moviesSeriesWatchListService.Add(moviesSeriesWatchList);
            return RedirectToAction("MoviesSeriesDetails", "MoviesSeries", new { id = id });
        }


        public ActionResult VoteMoviesSeries(int id,short rate)
        {
            User user = _userService.GetUsersByUserName(User.Identity.GetUserName());
            Rating rating = _ratingService.GetRatingByUserAndMovie(user.UserID, id);
            if (rating == null)
            {
                rating = new Rating();
                rating.MoviesSeriesID = id;
                rating.UserID = user.UserID;
                rating.Score = rate;
                _ratingService.Add(rating);
            }
            else
            {
                rating.MoviesSeriesID = id;
                rating.UserID = user.UserID;
                rating.Score = rate;
                _ratingService.Update(rating);
            }
            
            ViewBag.rating = rating;
            return View();
        }


        public ActionResult CommentMoviesSeries(int id, FormCollection frm)
        {
            User user = _userService.GetUsersByUserName(User.Identity.GetUserName());
            Rating rating = _ratingService.GetRatingByUserAndMovie(user.UserID, id);
            if (rating == null)
            {
                rating = new Rating();
                rating.MoviesSeriesID = id;
                rating.UserID = user.UserID;
                rating.Comment = frm["comment"];
                _ratingService.Add(rating);
            }
            else
            {
                rating.MoviesSeriesID = id;
                rating.UserID = user.UserID;
                rating.Comment = frm["comment"];
                _ratingService.Update(rating);
            }
            ViewBag.ratingComment = rating;
            ViewBag.AllComment = _ratingService.GetCommentByUserAndMovieWithInclude(id, "User", "RatingOfMovieSeries");
            return RedirectToAction("MoviesSeriesDetails","MoviesSeries",new { id = id });
        }

        public ActionResult SuggestMeMovie()
        {
            Random random = new Random();
           
            User user = _userService.GetUsersByUserName(User.Identity.GetUserName());
            //Rating rating = _ratingService.GetScoreByUserAndMovie(user.UserID, id);
            //ViewBag.rating = rating;
            List<MoviesSeries> SuggestMovie = _moviesSeriesService.GetAll();
            int rnd = random.Next(0, SuggestMovie.Count-1);
            MoviesSeries moviesSeries = SuggestMovie[rnd]; 
            return View(moviesSeries);
        }
    }
}
