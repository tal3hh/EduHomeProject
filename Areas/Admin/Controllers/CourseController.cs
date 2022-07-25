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
    public class CourseController : Controller
    {
        readonly IUow _uow;
        readonly AppDbContext _context;
        readonly IWebHostEnvironment _env;
        public CourseController(IUow uow, AppDbContext context, IWebHostEnvironment env)
        {
            _uow = uow;
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> CourseList()
        {
            var courses = await _context.Courses.OrderByDescending(x => x.Id).ToListAsync();

            return View(courses);
        }


        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Course course)
        {
            if (!ModelState.IsValid) return View();
            if (!course.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("", "Sekil Formatinda Bir Fayl Secin.");
                return View();
            }
            if (course.Photo.Length / 1024 > 500)
            {
                ModelState.AddModelError("", "Secdiyiniz sekil 500KB'dan az olmalidir.");
                return View();
            }

            string fileName = Guid.NewGuid().ToString() + "_" + course.Photo.FileName;
            string path = Path.Combine(_env.WebRootPath, "img/course", fileName);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await course.Photo.CopyToAsync(stream);
            }

            course.Image = fileName;

            await _uow.GetRepository<Course>().CreateAsync(course);

            return RedirectToAction("CourseList", "Course", new { area = "Admin" });
        }

        public async Task<IActionResult> Update(int id)
        {
            var course = await _uow.GetRepository<Course>().GetFindAsync(id);
            return View(course);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, Course course)
        {
            var DbCourse = await _context.Courses.FindAsync(id);
            if (!ModelState.IsValid) return View();
            if (!course.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("", "Sekil formatinda bir fayl secin.");
                return View();
            }
            if (course.Photo.Length / 1024 > 500)
            {
                ModelState.AddModelError("", "Secdiyiniz sekil 500KB az olmalidir.");
                return View();
            }

            string oldpath = Path.Combine(_env.WebRootPath, "img/course", DbCourse.Image);
            if (System.IO.File.Exists(oldpath))
            {
                System.IO.File.Delete(oldpath);
            }
            string fileName = Guid.NewGuid().ToString() + "_" + course.Photo.FileName;
            string newpath = Path.Combine(_env.WebRootPath, "img/course", fileName);
            using (FileStream stream = new FileStream(newpath, FileMode.Create))
            {
                await course.Photo.CopyToAsync(stream);
            }

            DbCourse.Image = fileName;
            DbCourse.Title = course.Title;
            DbCourse.Description = course.Description;

            await _context.SaveChangesAsync();

            return RedirectToAction("CourseList", "Course", new { area = "Admin" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null) return View();
            string path = Path.Combine(_env.WebRootPath, "img/course", course.Image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return RedirectToAction("CourseList", "Course", new { area = "Admin" });
        }

        public async Task<IActionResult> Details(int id)
        {
            var course = await _uow.GetRepository<Course>().GetFindAsync(id);

            return View(course);
        }
    }
}
