using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WrittenTest.DAL;
using WrittenTest.Models;

namespace WrittenTest.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentGateway gateway = new DepartmentGateway();
        // GET: Department
        public ActionResult Index()
        {
            return View(gateway.GetDepartmentList());
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Department dept)
        {
            gateway.SaveDepartment(dept);
            return RedirectToAction("Index");
        }
    }
}