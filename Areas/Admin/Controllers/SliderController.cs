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
    [Authorize(Roles = "Admin")]
    public class SliderController : Controller
    {
        readonly IUow _uow;
        readonly AppDbContext _context;
        readonly IWebHostEnvironment _env;
        public SliderController(IUow uow, AppDbContext context, IWebHostEnvironment env)
        {
            _uow = uow;
            _context = context;
            _env = env;
        }


        public async Task<IActionResult> SliderList()
        {
            var sliderlist = await _context.Sliders.OrderByDescending(x => x.Id).ToListAsync();

            return View(sliderlist);
        }


        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Slider slider)
        {
            if (!ModelState.IsValid)
                return View();
            if (!slider.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("", "Sekil formatinda bir fayl secin.");
                return View();
            }


            string fileName = Guid.NewGuid().ToString() + "_" + slider.Photo.FileName;
            string path = Path.Combine(_env.WebRootPath, "img/slider", fileName);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await slider.Photo.CopyToAsync(stream);
            }
            slider.Image = fileName;
            await _uow.GetRepository<Slider>().CreateAsync(slider);

            return RedirectToAction("SliderList", "Slider", new { area = "Admin" });
        }

        public async Task<IActionResult> Update(int id)
        {
            var slider = await _uow.GetRepository<Slider>().GetFindAsync(id);
            return View(slider);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id,Slider slider)
        {
            var DbSlider = await _context.Sliders.FindAsync(id);

            if (!ModelState.IsValid) return View(slider);

            if (!slider.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("", "Sekil formatinda bir fayl secin.");
                return View(slider);
            }

            string oldPath = Path.Combine(_env.WebRootPath, "img/slider", DbSlider.Image);
            if (System.IO.File.Exists(oldPath))
            {
                System.IO.File.Delete(oldPath);
            }
            string fileName = Guid.NewGuid().ToString() + "_" + slider.Photo.FileName;
            string newPath = Path.Combine(_env.WebRootPath, "img/slider", fileName);
            using(FileStream stream = new FileStream(newPath, FileMode.Create))
            {
                await slider.Photo.CopyToAsync(stream);
            }

            DbSlider.Image = fileName;
            DbSlider.Description = slider.Description;
            DbSlider.Title = slider.Title;

            await _context.SaveChangesAsync();
            return RedirectToAction("SliderList", "Slider", new { area = "Admin" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var slider = await _context.Sliders.FindAsync(id);
            if (slider == null) return NotFound();
            string path = Path.Combine(_env.WebRootPath, "img/slider", slider.Image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction("SliderList", "Slider", new { area = "Admin" });
        }

        public async Task<IActionResult> Details(int id)
        {
            var slider = await _uow.GetRepository<Slider>().GetFindAsync(id);
            return View(slider);
        }
    }
}
