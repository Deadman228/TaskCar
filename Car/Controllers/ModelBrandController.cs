using Car.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car.Controllers
{
    public class ModelBrandController : Controller
    {
        private readonly ApplicationContext _context;
        private static int idselected = 1;
        public ModelBrandController(ApplicationContext context)
        {
            _context = context;
        }
        public IActionResult modelbrandlist()
        {
            List<Brand> fruits = _context.brands.ToList();
            ViewBag.brands = _context.brands.ToList();
            ViewBag.models = _context.models.Where(x => x.brandid == idselected).ToList();
            return View(fruits);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LoadBrandModel(int brandidselected)
        {
            idselected = brandidselected;
            try
            {
                return RedirectToAction(nameof(modelbrandlist));
            }
            catch (DbUpdateException)
            {

            }
            return RedirectToAction(nameof(modelbrandlist));
        }

        [HttpPost]
        public ActionResult Submit(int id)
        {
            Brand brand = _context.brands.FirstOrDefault(x => x.id == id);
            _context.brands.Remove(brand);
            _context.SaveChanges();
            return RedirectToAction("modelbrandlist");
        }

        public string TellMeDate(string parameter)
        {


            return DateTime.Today.ToString() + "-->>>" + parameter + "!!!!";


        }
    }
}
