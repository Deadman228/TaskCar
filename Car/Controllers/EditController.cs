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
    public class EditController : Controller
    {
        private readonly ApplicationContext _context;
        public EditController(ApplicationContext context)
        {
            _context = context;
        }
        public IActionResult editlist(int? id)
        {
            Model user =  _context.models.FirstOrDefault(p => p.id == id);
            ViewBag.users = _context.models.ToList();
            return View();
        }
    }
}
