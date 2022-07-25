using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElmirProje.Contexts;
using ElmirProje.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElmirProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SubcribeeController : Controller
    {
        readonly AppDbContext _context;
        public SubcribeeController(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var list = await _context.Subscribees.OrderByDescending(x=> x.Id).ToListAsync();
            
            return View(list);
        }
        public async Task<IActionResult> Update(int id)
        {
            var subscribe = await _context.Subscribees.FindAsync(id);
            return View(subscribe);
        }
        [HttpPost]
        public IActionResult Update(Subscribee subscribee)
        {
            if (!ModelState.IsValid)
            {
                return View(subscribee);
            }
            _context.Subscribees.Update(subscribee);
            _context.SaveChanges();
            return RedirectToAction("Index", "Subcribee", new { area = "Admin" });
        }

        public IActionResult Delete(int id)
        {
            var entity = _context.Subscribees.Find(id);
            _context.Subscribees.Remove(entity);
            _context.SaveChanges();
            return RedirectToAction("Index", "Subcribee", new { area = "Admin" });
        }
    }
}
