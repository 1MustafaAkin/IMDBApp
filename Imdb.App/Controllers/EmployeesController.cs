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
    public class EmployeesController : Controller
    {
        private IEmployeeService _employeeService;
        private ICountryService _countryService;
        private IRoleService _roleService;

        public EmployeesController()
        {
            _employeeService = InstanceFactory.GetInstance<IEmployeeService>();
            _countryService = InstanceFactory.GetInstance<ICountryService>();
            _roleService = InstanceFactory.GetInstance<IRoleService>();
        }

        // GET: Employees
        public ActionResult Index()
        {
            //var employee = db.Employee.Include(e => e.Country).Include(e => e.Role);
            //Burda GetAll yerine bunu tercih etmemizin sebebi Country ve Role Tablolarını Employee tablosuna include etmemiz gerektiğinden doalyı
            var employee = _employeeService.GetAllWithInclude("Country","Role");
            return View(employee);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Employee employee = _employeeService.GetEmployeeById(id);
            Employee employee = _employeeService.GetAllWithIncludeById(id,"Country", "Role");
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.CountryID = new SelectList(_countryService.GetAll(), "CountryID", "CountryName");
            ViewBag.RoleID = new SelectList(_roleService.GetAll(), "RoleID", "Role");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,FirstName,LastName,BirthDate,CountryID,RoleID")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeService.Add(employee);
                return RedirectToAction("Index");
            }

            ViewBag.CountryID = new SelectList(_countryService.GetAll(), "CountryID", "CountryName", employee.CountryID);
            ViewBag.RoleID = new SelectList(_roleService.GetAll(), "RoleID", "Role", employee.RoleID);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryID = new SelectList(_countryService.GetAll(), "CountryID", "CountryName", employee.CountryID);
            ViewBag.RoleID = new SelectList(_roleService.GetAll(), "RoleID", "Role", employee.RoleID);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,FirstName,LastName,BirthDate,CountryID,RoleID")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeService.Update(employee);
                return RedirectToAction("Index");
            }
            ViewBag.CountryID = new SelectList(_countryService.GetAll(), "CountryID", "CountryName", employee.CountryID);
            ViewBag.RoleID = new SelectList(_roleService.GetAll(), "RoleID", "Role", employee.RoleID);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = _employeeService.GetEmployeeById(id);
            _employeeService.Delete(employee);
            return RedirectToAction("Index");
        }


    }
}
