using Car.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xceed.Wpf.Toolkit;

namespace Car.Controllers
{
    public class ModelController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly ApplicationContext idshnik;

        public ModelController(ApplicationContext context)
        {
            _context = context;
        }
        public IActionResult modellist()
        {
            
            ViewBag.kul = _context.brands.ToList();
            _context.models.OrderBy(c => c.id);
            ViewBag.users = _context.models.ToList();
            
            return View();
        }
        [HttpPost]
        public IActionResult modellist(int id, int brandid, string login, bool active, Model modik)
        {
            _context.models.Add(new Model
            {
                id = id,
                brandid = brandid,
                name = login,
                active = active,

        });
           
            _context.SaveChanges();
            return modellist();
        }
        [HttpGet]
        public IActionResult modellisy()
        {
            return View();
        }



        public IActionResult Edit(int? id, int brandid, string name, bool active)
        {
            if (id != null)
            {
                Model user = _context.models.FirstOrDefault(p => p.id == id);
                if (user != null)
                    return View();
            }
            return View();

        }
        [HttpPost]
        public IActionResult Edit(Model user, int number, int brandid, string name, bool active)
        {
            ViewBag.users = _context.models.ToList();
            Model ku = _context.models.FirstOrDefault(p => p.id == number);
            _context.models.Remove(ku);

            _context.models.Add(new Model
            {
                id = number,
                brandid = brandid,
                name = name,
                active = active,

            });


            try
            {
                _context.SaveChanges();
                return RedirectToAction(nameof(modellist));
            }
            catch (DbUpdateException)
            {

            }
            return RedirectToAction(nameof(modellist));
        }

        /*public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Model user = await _context.models.FirstOrDefaultAsync(p => p.id == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Model user)
        {
            _context.models.Update(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Model user = await _context.models.FirstOrDefaultAsync(p => p.id == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }*/
        /* public async Task<IActionResult> Index()
         {
             return View(await _context.models.ToListAsync());
         }
         public IActionResult Create()
         {
             return View(modellist());
         }
         [HttpPost]
         public async Task<IActionResult> Create(Model modeles)
         {
             _context.models.Add(modeles);
             await _context.SaveChangesAsync();
             return RedirectToAction("Index");
         }*/

        /*[HttpGet]
        [ActionName("Delete")]
       *//* public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Model user = await _context.models.FirstOrDefaultAsync(p => p.id == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }*//*

        [HttpPost]
        public async Task<IActionResult>Delete(int? id)
        {
            if (id != null)
            {
                Model user = await _context.models.FirstOrDefaultAsync(p => p.id == id);
                if (user != null)
                {
                    _context.models.Remove(user);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var person = await _context.models.FindAsync(id);
 
            if (person != null)
            {
                _context.models.Remove(person);
                await _context.SaveChangesAsync();
            }
 
            return NotFound();
        }*/
    }
}
