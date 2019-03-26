using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Imdb.App.Models;
using Imdb.BLL.Abstract;
using Imdb.BLL.DependencyResolver.Ninject;
using Imdb.DAL;
using Imdb.DATA.Concrete;
using PagedList;
namespace Imdb.App.Controllers
{
    public class NewsController : Controller
    {
        INewsService _newsService;

        public NewsController()
        {
            _newsService = InstanceFactory.GetInstance<INewsService>();
        }

        // GET: News
        public ActionResult Index()
        {
            return View(_newsService.GetAll());
        }

        // GET: News/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = _newsService.GetNewsById(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // GET: News/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: News/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NewsID,NewsTitle,NewsContent,NewsPhoto")] News news, Picture picture)
        {
            if (ModelState.IsValid)
            {
                var fileName = "";
                var physicalPath = "";
                var relativePath = "";
                if (picture.File != null && picture.File.ContentLength > 0)
                {
                    relativePath = "~/Content/images/news/" + Path.GetFileName(picture.File.FileName);
                    physicalPath = Server.MapPath(relativePath);
                    picture.File.SaveAs(physicalPath);
                }

                news.NewsPhoto = relativePath + fileName;
                _newsService.Add(news);
            }

            return RedirectToAction("Index");
        }

        // GET: News/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = _newsService.GetNewsById(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: News/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NewsID,NewsTitle,NewsContent,NewsPhoto")] News news)
        {
            if (ModelState.IsValid)
            {
                _newsService.Update(news);
                return RedirectToAction("Index");
            }
            return View(news);
        }

        // GET: News/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = _newsService.GetNewsById(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            News news = _newsService.GetNewsById(id);
            _newsService.Delete(news);
            return RedirectToAction("Index");
        }

        public ActionResult ListOfNews()
        {
            return View(_newsService.GetAll());
        }
        public ActionResult NewsDetails(int id)
        {
            return View(_newsService.GetNewsById(id));
        }

    }
}
