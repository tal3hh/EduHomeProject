using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElmirProje.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace ElmirProje.ViewComponents
{
    public class SideBarCourse : ViewComponent
    {
        private readonly AppDbContext _context;
        public SideBarCourse(AppDbContext context)
        {
            _context = context;
        }


        public IViewComponentResult Invoke()
        {
            var courses = _context.Courses.OrderByDescending(x => x.Id).ToList();
            var blogs = _context.Blogs.OrderByDescending(x => x.Id).ToList();
            var tags = _context.TagTables.OrderBy(x => x.Id).ToList();

            return View((courses, blogs, tags));
        }

    }
}
