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

    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        public BlogController(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var blogs = await _context.Blogs.OrderByDescending(x => x.Id).ToListAsync();

            return View(blogs);
        }

        public async Task<IActionResult> BlogSideBar()
        {
            var blogs = await _context.Blogs.OrderByDescending(x => x.Id).ToListAsync();

            return View(blogs);
        }


        public async Task<IActionResult> BlogDetails(int id)
        {
            var blogdetails = await _context.Blogs.FirstOrDefaultAsync(x => x.Id==id);

            return View((blogdetails, new Contact()));
        }

        [HttpPost]
        public async Task<IActionResult> BlogDetails([Bind(Prefix ="Item2")] Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return View(contact);
            }

            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();

            return RedirectToAction("BlogDetails", "Blog");
        }
    }
}
