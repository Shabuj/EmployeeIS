using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WrittenTest.DAL;
using WrittenTest.Models;


namespace WrittenTest.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeGateway gateway = new EmployeeGateway();
        // GET: Employee
        public ActionResult Index()
        {
            var employeeLists= gateway.GetEmployees();
            return View(employeeLists);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var departments = gateway.GetDepartmentList();
            var cities = gateway.GetCityList();
            ViewBag.Departments = new SelectList(departments, "DepartmentId", "DepartmentName");
            ViewBag.Cities = new SelectList(cities, "CityId", "CityName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            gateway.CreateEmployee(employee);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var employeeById = gateway.DeleteEmployeeItem(id);
            return View(employeeById);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            gateway.DeleteEmployeeById(id);
            return RedirectToAction("Index", "Employee");
        }

        public ActionResult Details(int id)
        {
            var employeeDetails = gateway.employeeDetailsById(id);
            return View(employeeDetails);
        }

        public ActionResult Edit(int id)
        {
            var departments = gateway.GetDepartmentList();
            var cities = gateway.GetCityList();
            ViewBag.Departments = new SelectList(departments, "DepartmentId", "DepartmentName");
            ViewBag.Cities = new SelectList(cities, "CityId", "CityName");
            var employeeEditItem = gateway.EmployeeItemById(id); 
            return View(employeeEditItem);
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            gateway.UpdateEmployee(employee);
            return RedirectToAction("Index");
            
        }

      
    }
}