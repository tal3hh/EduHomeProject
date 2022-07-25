using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElmirProje.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace ElmirProje.ViewComponents
{
    public class About: ViewComponent
    {
        private readonly AppDbContext _context;

        public About(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var about = _context.About.OrderByDescending(x => x.Id).ToList();
                
            return View(about);
        }
    }
}
