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
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Imdb.App.Controllers
{
    public class UserProfilesController : Controller
    {


        private readonly Context db;
        private IUserService _userService;
        private IApplicationUserService _applicationUserService;

        public UserProfilesController()
        {

            _userService = InstanceFactory.GetInstance<IUserService>();
            _applicationUserService = InstanceFactory.GetInstance<IApplicationUserService>();
            if (db == null)
                db = new Context();
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
        public ActionResult UpdateProfile(int id, FormCollection form)
        {
            User user = _userService.GetUsersById(id);


            user.Password = form["Password"];
            user.Email = form["Email"];
            user.FirstName = form["FirstName"];
            user.LastName = form["LastName"];
            user.BirthDate = Convert.ToDateTime(form["BirthDate"]);
            _userService.Update(user);
            return RedirectToAction("Index");
        }

        public ActionResult ChangePassword(int id, FormCollection form)
        {
            User user = _userService.GetUsersById(id);
            ApplicationUser appUser = db.Users.FirstOrDefault(x => x.User.UserID == user.UserID);
            user.Password = form["NewPassword"];

            var provider = new DpapiDataProtectionProvider("Imdb.App");
            var userStore = new UserStore<ApplicationUser>(db);
            var manager = new ApplicationUserManager(userStore);

            manager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(provider.Create("Imdb.App"));
            var token = manager.GeneratePasswordResetToken(appUser.Id);
            manager.ResetPassword(appUser.Id, token, user.Password);
            _userService.Update(user);
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
