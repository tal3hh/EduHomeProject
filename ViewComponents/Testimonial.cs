using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElmirProje.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace ElmirProje.ViewComponents
{
    public class Testimonial : ViewComponent
    {
        private readonly AppDbContext _context;

        public Testimonial(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var testimonials = _context.Testimonials.OrderByDescending(x=> x.Id).ToList();

            return View(testimonials);
        }
    }
}
