using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ElmirProje.Contexts;
using ElmirProje.Models;
using ElmirProje.UniteOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace ElmirProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class EventController : Controller
    {
        readonly IUow _uow;
        readonly AppDbContext _context;
        readonly IWebHostEnvironment _env;
        public EventController(IUow uow, AppDbContext context, IWebHostEnvironment env)
        {
            _uow = uow;
            _context = context;
            _env = env;
        }


        public async Task<IActionResult> EventList()
        {
            var eventlist = await _uow.GetRepository<Event>().GetAllAsync();

            return View(eventlist);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Event eventlist)
        {
            if (!ModelState.IsValid)
                return View();
            if (!eventlist.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("", "Sekil formatinda bir fayl secin.");
                return View();
            }

            string fileName = Guid.NewGuid().ToString() + "_" + eventlist.Photo.FileName;
            string path = Path.Combine(_env.WebRootPath, "img/event", fileName);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await eventlist.Photo.CopyToAsync(stream);
            }
            eventlist.Image = fileName;

            await _uow.GetRepository<Event>().CreateAsync(eventlist);

            return RedirectToAction("EventList", "Event", new { area = "Admin" });
        }

        public async Task<IActionResult> Update(int id)
        {
            var eventlist = await _uow.GetRepository<Event>().GetFindAsync(id);

            return View(eventlist);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id,Event eventlist)
        {
            var DbEvent = await _context.Events.FindAsync(id);

            if (!ModelState.IsValid) return View();

            if (!eventlist.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("", "Sekil formatinda bir fayl secin.");
                return View();
            }

            string oldPath = Path.Combine(_env.WebRootPath, "img/event", DbEvent.Image);
            if (System.IO.File.Exists(oldPath))
            {
                System.IO.File.Delete(oldPath);
            }
            string fileName = Guid.NewGuid().ToString() + "_" + eventlist.Photo.FileName;
            string newPath = Path.Combine(_env.WebRootPath, "img/event", fileName);
            using (FileStream stream = new FileStream(newPath, FileMode.Create))
            {
                await eventlist.Photo.CopyToAsync(stream);
            }

            DbEvent.Image = fileName;
            DbEvent.Description = eventlist.Description;
            DbEvent.StartDate = eventlist.StartDate;
            DbEvent.EndDate = eventlist.EndDate;
            DbEvent.Location = eventlist.Location;
            DbEvent.Title = eventlist.Title;

            await _context.SaveChangesAsync();
            return RedirectToAction("EventList", "Event", new { area = "Admin" });
        }
        public async Task<IActionResult> Delete(int id)
        {
            var events = await _context.Events.FindAsync(id);
            if (events == null) return NotFound();
            string path = Path.Combine(_env.WebRootPath, "img/slider", events.Image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            _context.Events.Remove(events);
            await _context.SaveChangesAsync();

            return RedirectToAction("EventList", "Event", new { area = "Admin" });
        }

        public async Task<IActionResult> Details(int id)
        {
            var eventlist = await _uow.GetRepository<Event>().GetFindAsync(id);

            return View(eventlist);
        }
    }
}
