using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WrittenTest.DAL;
using WrittenTest.Models;

namespace WrittenTest.Controllers
{
    public class CityController : Controller
    {
        // GET: City
        CityGateway gateway = new CityGateway();
        
        public ActionResult Index()
        {
            return View(gateway.GetCityList());
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(City city)
        {
            gateway.SaveCity(city);
            return RedirectToAction("Index");
        }
    }
}