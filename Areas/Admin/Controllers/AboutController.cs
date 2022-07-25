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
using Microsoft.EntityFrameworkCore;

namespace ElmirProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class AboutController : Controller
    {
        readonly IUow _uow;
        readonly AppDbContext _context;
        readonly IWebHostEnvironment _env;
        public AboutController(IUow uow, AppDbContext context, IWebHostEnvironment env)
        {
            _uow = uow;
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> AboutList()
        {
            var abouts = await _context.Sliders.OrderByDescending(x => x.Id).ToListAsync();

            return View(abouts);
        }


        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(About about)
        {
            if (!ModelState.IsValid)
                return View();
            if (!about.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("", "Sekil formatinda bir fayl secin.");
                return View();
            }


            string fileName = Guid.NewGuid().ToString() + "_" + about.Photo.FileName;
            string path = Path.Combine(_env.WebRootPath, "img/about", fileName);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await about.Photo.CopyToAsync(stream);
            }
            about.Image = fileName;

            await _uow.GetRepository<About>().CreateAsync(about);

            return RedirectToAction("AboutList", "About", new { area = "Admin" });
        }

        public async Task<IActionResult> Update(int id)
        {
            var about = await _uow.GetRepository<About>().GetFindAsync(id);
            return View(about);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id,About about)
        {
            var Dbabout = await _context.About.FindAsync(id);

            if (!ModelState.IsValid) return View(about);

            if (!about.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("", "Sekil formatinda bir fayl secin.");
                return View(about);
            }

            string oldPath = Path.Combine(_env.WebRootPath, "img/slider", Dbabout.Image);
            if (System.IO.File.Exists(oldPath))
            {
                System.IO.File.Delete(oldPath);
            }
            string fileName = Guid.NewGuid().ToString() + "_" + about.Photo.FileName;
            string newPath = Path.Combine(_env.WebRootPath, "img/slider", fileName);
            using (FileStream stream = new FileStream(newPath, FileMode.Create))
            {
                await about.Photo.CopyToAsync(stream);
            }

            Dbabout.Image = fileName;
            Dbabout.Description = about.Description;
            Dbabout.Title = about.Title;

            await _context.SaveChangesAsync();
            return RedirectToAction("AboutList", "About", new { area = "Admin" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var about = await _context.About.FindAsync(id);
            if (about == null) return NotFound();
            string path = Path.Combine(_env.WebRootPath, "img/slider", about.Image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            _context.About.Remove(about);
            await _context.SaveChangesAsync();
            return RedirectToAction("AboutList", "About", new { area = "Admin" });
        }

        public async Task<IActionResult> Details(int id)
        {
            var about = await _uow.GetRepository<About>().GetFindAsync(id);
            return View(about);
        }
    }
}
