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
    public class CourseFeaturesController : Controller
    {
        readonly AppDbContext _context;
        public CourseFeaturesController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> CourseFeaturesList()
        {
            var courseFeatures = await _context.CourseFeatures.Include(x => x.Course).ToListAsync();

            return View(courseFeatures);
        }


        public IActionResult Create()
        {
            var courselist = _context.Courses.ToList();

            var courseFeatures = new CourseFeatures();

            return View((courseFeatures, courselist));
        }
        [HttpPost]
        public IActionResult Create([Bind(Prefix = "Item1")] CourseFeatures details)
        {
            if (!ModelState.IsValid)
            {
                return View(details);
            }
            _context.CourseFeatures.Add(details);
            _context.SaveChanges();

            return RedirectToAction("CourseFeaturesList", "CourseFeatures", new { area = "Admin" });
        }

        public async Task<IActionResult> Update(int id)
        {
            var details = await _context.CourseFeatures.FindAsync(id);
            var course = await _context.Courses.ToListAsync();

            return View((details, course));
        }
        [HttpPost]
        public IActionResult Update([Bind(Prefix = "Item1")] CourseFeatures courseFeatures)
        {
            if (!ModelState.IsValid)
            {
                return View(courseFeatures);
            }
            _context.CourseFeatures.Update(courseFeatures);
            _context.SaveChanges();

            return RedirectToAction("CourseFeaturesList", "CourseFeatures", new { area = "Admin" });
        }

        public IActionResult Delete(int id)
        {
            var courseFeatures = _context.CourseFeatures.Find(id);
            _context.CourseFeatures.Remove(courseFeatures);
            _context.SaveChanges();

            return RedirectToAction("CourseFeaturesList", "CourseFeatures", new { area = "Admin" });
        }

        public IActionResult Details(int id)
        {
            var details = _context.CourseFeatures.Include(x => x.Course).FirstOrDefault(x => x.Id == id);
            return View(details);
        }
    }
}
