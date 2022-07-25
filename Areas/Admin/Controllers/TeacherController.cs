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
    public class TeacherController : Controller
    {
        readonly IUow _uow;
        readonly AppDbContext _context;
        readonly IWebHostEnvironment _env;
        public TeacherController(IUow uow, AppDbContext context, IWebHostEnvironment env)
        {
            _uow = uow;
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> TeacherList()
        {
            var teachers = await _uow.GetRepository<Teacher>().GetAllAsync();
            return View(teachers);
        }


        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Teacher teacher)
        {
            if (!ModelState.IsValid) return View(teacher);
            if (!teacher.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("", "Sekil formatinda bir fayl secin.");
                return View();
            }

            string fileName = Guid.NewGuid().ToString() + "_" + teacher.Photo.FileName;

            string path = Path.Combine(_env.WebRootPath, "img/teacher", fileName);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await teacher.Photo.CopyToAsync(stream);
            }

            teacher.Image = fileName;
            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();

            return RedirectToAction("TeacherList", "Teacher", new { area = "Admin" });
        }

        public async Task<IActionResult> Update(int id)
        {
            var service = await _uow.GetRepository<Teacher>().GetFindAsync(id);
            return View(service);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, Teacher teacher)
        {
            var DbTeacher = await _context.Teachers.FindAsync(id);
            if (!ModelState.IsValid) return View();
            if (!teacher.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("", "Sekil formatinda bir fayl secin.");
                return View();
            }

            string oldpath = Path.Combine(_env.WebRootPath, "img/teacher", DbTeacher.Image);
            if (System.IO.File.Exists(oldpath))
            {
                System.IO.File.Delete(oldpath);
            }

            string fileName = Guid.NewGuid().ToString() + "_" + teacher.Photo.FileName;
            string newpath = Path.Combine(_env.WebRootPath, "img/teacher", fileName);
            using (FileStream stream = new FileStream(newpath, FileMode.Create))
            {
                await teacher.Photo.CopyToAsync(stream);
            }
            DbTeacher.Image = fileName;
            DbTeacher.Faculty = teacher.Faculty;
            DbTeacher.Mail = teacher.Mail;
            DbTeacher.MakeACall = teacher.MakeACall;
            DbTeacher.AboutMe = teacher.AboutMe;
            DbTeacher.Degree = teacher.Degree;
            DbTeacher.Hobbies = teacher.Hobbies;
            DbTeacher.Experience = teacher.Experience;
            DbTeacher.Fullname = teacher.Fullname;
            DbTeacher.Work = teacher.Work;
            DbTeacher.Skype = teacher.Skype;

            await _context.SaveChangesAsync();

            return RedirectToAction("TeacherList", "Teacher", new { area = "Admin" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null) return NotFound();
            string path = Path.Combine(_env.WebRootPath, "img/teacher", teacher.Image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();

            return RedirectToAction("TeacherList", "Teacher", new { area = "Admin" });
        }

        public async Task<IActionResult> Details(int id)
        {
            var teacher = await _uow.GetRepository<Teacher>().GetFindAsync(id);

            return View(teacher);
        }
    }
}
