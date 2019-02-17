using Microsoft.EntityFrameworkCore;
using CRUDelicious.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace CRUDelicious.Controllers
{
    public class DishesController : Controller
    {
        private CRUDContext dbContext;
        public DishesController(CRUDContext context)
        {
            dbContext = context;
        }
     
        [HttpGet("")]
        public IActionResult Index()
        {
            List<Chef> AllChefs = dbContext.chefs.Include(u=> u.Dishes).ToList();
            foreach(var x in AllChefs)
            {
                var now = DateTime.Today;
                var chefAge = x.Age - now;
                string strChef = chefAge.ToString("%d");
                int intChef = Int32.Parse(strChef);
                intChef /= 365;
                x.DoB = intChef;

            }
            ViewBag.Chefs = AllChefs;
            return View("index");
        }

        [HttpGet("dishes")]
        public IActionResult Dishes()
        {
            List<Dishes> AllDishes= dbContext.dishes.Include(u=> u.Chef).ToList();
            ViewBag.Dishes = AllDishes;
            return View("dishes");
        }
        [HttpGet("new")]
        public IActionResult New()
        {
            return View("new");
        }

        [HttpGet("dishes/new")]
        public IActionResult NewDish()
        {
            List<Chef> AllChefs = dbContext.chefs.ToList();
            ViewBag.Chefs = AllChefs;
            return View("newdish");
        }
        
        [HttpPost("addchef")]
        public IActionResult AddChef(Chef chef)
        {
            if(ModelState.IsValid)
            {
                var now = DateTime.Today;
                var chefAge = now - chef.Age;
                DateTime day1 = new DateTime(2018,1,1);
                DateTime day2 = new DateTime(2000,1,1);
                var eighteen = day1 - day2;
                if(chefAge > eighteen){
                    dbContext.Add(chef);
                    dbContext.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Age" , "Age should be minimum 18");
                    return View("new");
                }
                
            }
            else
            {
                return View("new");
            }
           
        }

        [HttpPost("create/dish")]
        public IActionResult CreateDish(Dishes dish)
        {
            if(ModelState.IsValid)
            {
                dbContext.Add(dish);
                dbContext.SaveChanges();
                return RedirectToAction("dishes");
            }
            else
            {
                List<Chef> AllChefs = dbContext.chefs.ToList();
                ViewBag.Chefs = AllChefs;
                return View("newdish");
            }
           
        }
    }
}