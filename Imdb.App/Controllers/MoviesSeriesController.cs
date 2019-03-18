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
using Microsoft.AspNet.Identity;

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
            moviesSeriesCategory = new MoviesSeriesCategory();
        }

        private IMoviesSeriesService _moviesSeriesService;
        private IUserService _userService;
        private ICategoryService _categoryService;
        private IEmployeeService _employeeService;
        private IMoviesSeriesCategoryService _moviesSeriesCategoryService;
        private IMoviesSeriesEmployeeService _moviesSeriesEmployeeService;
        private IMoviesSeriesWatchListService _moviesSeriesWatchListService;
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

        public ActionResult ListOfMovies()
        {
            return View(_moviesSeriesService.GetMoviesSeriesByIsMovies());
        }

        public ActionResult ListOfSeries()
        {
            return View(_moviesSeriesService.GetMoviesSeriesByIsSeries());
        }

        List<Employee> employees;
        int sayac = 0;
        public ActionResult MoviesSeriesDetails(int id)
        {
            User user = _userService.GetUsersByUserName(User.Identity.GetUserName());
            List<MoviesSeriesEmployee> employeesOfMoviesSeries = _moviesSeriesEmployeeService.GetEmployeeByMoviesSeriesId(id);
            List<MoviesSeriesWatchList> moviesSeriesWatchList = _moviesSeriesWatchListService.GetMoviesSeriesWatchListByWatchList(user.UserID);

            sayac = moviesSeriesWatchList.Where(x=>x.MoviesSeriesID == id).ToList().Count();
            if (sayac != 0)
                ViewBag.DoesExistMovieInWatchList = true;
            else
                ViewBag.DoesExistMovieInWatchList = false;

            employees = new List<Employee>();
            foreach (var item in employeesOfMoviesSeries)
            {
                employees.Add(_employeeService.GetEmployeeById(item.EmployeeID));
            }
            ViewBag.EmployeeOfMoviesSeries = employees;
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
    }
}
