using Car.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car.Controllers
{
    public class BrandController : Controller
    {
        private readonly ApplicationContext _context;
        public BrandController(ApplicationContext context)
        {
            _context = context;
        }
        public IActionResult brandlist()
        {
            ViewBag.ku = _context.brands.ToList();
            return View();
        }

        static List<Brand> comps = new List<Brand>();
        public ActionResult Index()
        {
            return View(comps);
        }
        public ActionResult Details(int id)
        {
            Brand c = comps.FirstOrDefault(com => com.id == id);
            if (c != null)
                return PartialView(c);
            return View();
        }



        [HttpPost]
        public IActionResult brandlist(int id, int brandid, string login, bool active, Brand modik)
        {
            _context.brands.Add(new Brand
            {
                id = _context.brands.Count()+1,
                name = login,
                active = active

            });

            _context.SaveChanges();
            return brandlist();
        }



        public IActionResult Edit(int? id, int brandid, string name, bool active)
        {
            if (id != null)
            {
                Brand user = _context.brands.FirstOrDefault(p => p.id == id);
                if (user != null)
                    return View();
            }
            return View();

        }
        [HttpPost]
        public IActionResult Edit(Brand user, int number, int brandid, string name, bool active)
        {
            ViewBag.users = _context.brands.ToList();
            Brand ku = _context.brands.FirstOrDefault(p => p.id == number);
            _context.brands.Remove(ku);

            _context.brands.Add(new Brand
            {
                id = number,
                name = name,
                active = active,

            });


            try
            {
                _context.SaveChanges();
                return RedirectToAction(nameof(brandlist));
            }
            catch (DbUpdateException)
            {

            }
            return RedirectToAction(nameof(brandlist));
        }

    }
}
