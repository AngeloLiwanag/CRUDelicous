using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Crudelicious.Models;
using Microsoft.EntityFrameworkCore;

namespace Crudelicious.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;
        public HomeController(MyContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            List<Dish> AllDishes = dbContext.Dishes.ToList();
            return View(AllDishes);
        }

        [HttpGet("new")]
        public IActionResult New()
        {
            return View("Create");
        }

        [HttpPost("create")]
        public IActionResult Create(Dish newDish)
        {
            dbContext.Add(newDish);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("show/{id}")]
        public IActionResult Show(int id)
        {
            var oneDish = dbContext.Dishes.FirstOrDefault(d => d.id == id);
            if(oneDish == null)
                return RedirectToAction("Index");
            return View("Read", oneDish);
        }

        [HttpGet("edit/{id}")]
        public IActionResult Edit(int id)
        {
            var oneDish = dbContext.Dishes.FirstOrDefault(d => d.id == id);
            if(oneDish == null)
                return RedirectToAction("Index");
            return View("Update", oneDish);
        }

        [HttpPost]
        public IActionResult Update(Dish dish, int id)
        {
            var oneDish = dbContext.Dishes.FirstOrDefault(d => d.id == id);
            if(oneDish == null)
                return RedirectToAction("Index");
            oneDish.Chef = dish.Chef;
            oneDish.Name = dish.Name;
            oneDish.Calories = dish.Calories;
            oneDish.Tastiness = dish.Tastiness;
            oneDish.Description = dish.Description;

            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var oneDish = dbContext.Dishes.FirstOrDefault(d => d.id == id);
            if(oneDish == null)
                return RedirectToAction("Index");
            dbContext.Dishes.Remove(oneDish);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
