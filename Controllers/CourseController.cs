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

    public class CourseController : Controller
    {
        private readonly AppDbContext _context;

        public CourseController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var course = await _context.Courses.OrderByDescending(x => x.Id).ToListAsync();

            return View(course);
        }


        public IActionResult CourseDetails(int id)
        {
            var course = _context.Courses.Include(x => x.CourseDetails).Include(x => x.CourseFeatures).FirstOrDefault(x => x.Id == id);
            var courses = _context.Courses.OrderByDescending(x => x.Id).ToList();
            var blogs = _context.Blogs.OrderByDescending(x => x.Id).ToList();
            var tags = _context.TagTables.OrderBy(x => x.Id).ToList();
            var contact = new Contact();
            return View((course, courses, blogs, tags, contact));
        }
        [HttpPost]
        public async Task<IActionResult> CourseDetails([Bind(Prefix = "Item5")] Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return View(contact);
            }

            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();


            return RedirectToAction("CourseDeatils", "Course");
        }

        public async Task<IActionResult> CourseSearch(string search)
        {
            var courses = from m in _context.Courses select m;

            if (!String.IsNullOrEmpty(search))
            {
                courses = courses.Where(x => x.Title.Contains(search));
            }

            return View(await courses.ToListAsync());
        }

        


    }
}
