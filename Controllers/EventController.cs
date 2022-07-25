using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElmirProje.Contexts;
using ElmirProje.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElmirProje.Controllers
{
    [Authorize(Roles = "Admin,Member")]

    public class EventController : Controller
    {
        private readonly AppDbContext _context;
        public EventController(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var events = await _context.Events.OrderByDescending(x => x.Id).ToListAsync();

            return View(events);
        }

        public async Task<IActionResult> EventDetails(int id)
        {
            var teachers = await _context.EventTeachers.Where(x => x.EventId == id).Include(x => x.Teacher).ToListAsync();
            var events = await _context.EventTeachers.Include(x => x.Event).FirstOrDefaultAsync(x => x.EventId == id);
            
            return View((events, teachers, new Contact()));
        }

        [HttpPost]
        public async Task<IActionResult> EventDetails([Bind(Prefix ="Item3")]Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return View(contact);
            }

            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();

            return RedirectToAction("Comment", "Event");
        }
    }
}
