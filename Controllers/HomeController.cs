using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElmirProje.Contexts;
using ElmirProje.Models;
using ElmirProje.UniteOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElmirProje.Controllers
{
    [Authorize(Roles = "Admin,Member")]

    public class HomeController : Controller
    {
        readonly IUow _uow;
        readonly AppDbContext _context;
        public HomeController(IUow uow, AppDbContext context)
        {
            _uow = uow;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var slider = await _uow.GetRepository<Slider>().GetAllAsync();
            var servive = await _uow.GetRepository<Service>().GetAllAsync();
            
            var course = await _context.Courses.OrderByDescending(x => x.Id).ToListAsync();
            
            var events = await _context.Events.OrderByDescending(x => x.Date).ToListAsync();
            var testimonials = await _context.Testimonials.ToListAsync();
            var blog = await _context.Blogs.ToListAsync();
            

            (List<Service>, List<Slider>,List<Course>,List<Event>, List<Testimonial>, List<Blog>) tuple = (servive, slider, course, events, testimonials, blog);

            return View(tuple);
        }
        [HttpPost]
        public async Task<IActionResult> Subscribee(Subscribee subscribee)
        {
            if (!ModelState.IsValid)
            {
                return View(subscribee);
            }

            await _uow.GetRepository<Subscribee>().CreateAsync(subscribee);
            
            return RedirectToAction("Index","Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
