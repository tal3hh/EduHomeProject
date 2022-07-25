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
    public class BlogController : Controller
    {
        readonly IUow _uow;
        readonly AppDbContext _context;
        readonly IWebHostEnvironment _env;
        public BlogController(IUow uow, AppDbContext context, IWebHostEnvironment env)
        {
            _uow = uow;
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> BlogList()
        {
            var blogs = await _context.Blogs.OrderByDescending(x => x.Id).ToListAsync();
            return View(blogs);
        }


        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Blog blog)
        {
            if (!ModelState.IsValid)
                return View();
            if (!blog.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("", "Sekil formatinda bir fayl secin.");
                return View();
            }

            string fileName = Guid.NewGuid().ToString() + "_" + blog.Photo.FileName;
            string path = Path.Combine(_env.WebRootPath, "img/blog", fileName);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await blog.Photo.CopyToAsync(stream);
            }
            blog.Image = fileName;

            await _uow.GetRepository<Blog>().CreateAsync(blog);

            return RedirectToAction("BlogList", "Blog", new { area = "Admin" });
        }



        public async Task<IActionResult> Update(int id)
        {
            var blog = await _uow.GetRepository<Blog>().GetFindAsync(id);
            return View(blog);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, Blog blog)
        {
            var DbBlog = await _context.Blogs.FindAsync(id);

            if (!ModelState.IsValid) return View(blog);

            if (!blog.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("", "Sekil formatinda bir fayl secin.");
                return View(blog);
            }

            string oldPath = Path.Combine(_env.WebRootPath, "img/blog", DbBlog.Image);
            if (System.IO.File.Exists(oldPath))
            {
                System.IO.File.Delete(oldPath);
            }
            string fileName = Guid.NewGuid().ToString() + "_" + blog.Photo.FileName;
            string newPath = Path.Combine(_env.WebRootPath, "img/blog", fileName);
            using (FileStream stream = new FileStream(newPath, FileMode.Create))
            {
                await blog.Photo.CopyToAsync(stream);
            }

            DbBlog.Image = fileName;
            DbBlog.Description = blog.Description;
            DbBlog.Title = blog.Title;

            await _context.SaveChangesAsync();
            return RedirectToAction("BlogList", "Blog", new { area = "Admin" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            if (blog == null) return NotFound();
            string path = Path.Combine(_env.WebRootPath, "img/blog", blog.Image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();
            return RedirectToAction("BlogList", "Blog", new { area = "Admin" });
        }

        public async Task<IActionResult> Details(int id)
        {
            var blog = await _uow.GetRepository<Blog>().GetFindAsync(id);

            return View(blog);
        }
    }
}
