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
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Imdb.App.Controllers
{
    public class UserProfilesController : Controller
    {


        private IUserService _userService;
        private IApplicationUserService _applicationUserService;

        public UserProfilesController()
        {
            _userService = InstanceFactory.GetInstance<IUserService>();
            _applicationUserService = InstanceFactory.GetInstance<IApplicationUserService>();
        }

        public ActionResult Index()
        {

            User user = (User)Session["OnlineKullaniciID"];
            return View(user);
        }

        [HttpPost]
        public ActionResult ChangeAvatar(Picture picture)
        {
            var fileName = "";
            var physicalPath = "";
            var relativePath = "";
            if (picture.File.ContentLength > 0)
            {
                relativePath = "~/Content/images/uploads/" + Path.GetFileName(picture.File.FileName);
                physicalPath = Server.MapPath(relativePath);
                picture.File.SaveAs(physicalPath);
                //fileName = Path.GetFileName(picture.File.FileName);
                //physicalPath = Path.Combine(Server.MapPath("~/Content/images/uploads/"), fileName);
                //picture.File.SaveAs(physicalPath);
            }

            User user = (User)Session["OnlineKullaniciID"];

            user.Avatar = relativePath + fileName;

            _userService.Update(user);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult UpdateProfile(int id,FormCollection form)
        {
            User user = _userService.GetUsersById(id);
            ApplicationUser appUser = _applicationUserService.GetApplicationUserByUserId(id);
            user.UserName = appUser.Email = appUser.UserName =form["UserName"];
            user.Email = form["Email"];
            user.FirstName = form["FirstName"];
            user.LastName = form["LastName"];
            user.BirthDate = Convert.ToDateTime(form["BirthDate"]);
            _applicationUserService.Update(appUser);
            _userService.Update(user);
            //TODO User update edildiğinde sessionunda update edilmesi lazım düzeltilecek
            Session["OnlineKullanici"] = appUser.Email;
            return RedirectToAction("Index");
        }

        //// GET: UserProfiles/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    User user = _userService.GetUsersById(id);
        //    if (user == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(user);
        //}
    }
}
