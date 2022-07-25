using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElmirProje.Models;
using ElmirProje.UniteOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElmirProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class TestimonialController : Controller
    {
        readonly IUow _uow;
        public TestimonialController(IUow uow)
        {
            _uow = uow;
        }

        public async Task<IActionResult> TestimonialList()
        {
            var servicelist = await _uow.GetRepository<Testimonial>().GetAllAsync();

            return View(servicelist);
        }


        public IActionResult Create()
        {
            var service = new Testimonial();
            return View(service);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Testimonial service)
        {
            if (!ModelState.IsValid)
            {
                return View(service);
            }
            await _uow.GetRepository<Testimonial>().CreateAsync(service);

            return RedirectToAction("TestimonialList", "Testimonial", new { area = "Admin" });
        }

        public async Task<IActionResult> Update(int id)
        {
            var service = await _uow.GetRepository<Testimonial>().GetFindAsync(id);
            return View(service);
        }
        [HttpPost]
        public IActionResult Update(Testimonial service)
        {
            if (!ModelState.IsValid)
            {
                return View(service);
            }
            _uow.GetRepository<Testimonial>().Update(service);
            return RedirectToAction("TestimonialList", "Testimonial", new { area = "Admin" });
        }

        public IActionResult Delete(int id)
        {
            _uow.GetRepository<Testimonial>().Remove(id);
            return RedirectToAction("TestimonialList", "Testimonial", new { area = "Admin" });
        }

        public async Task<IActionResult> Details(int id)
        {
            var service = await _uow.GetRepository<Testimonial>().GetFindAsync(id);
            return View(service);
        }
    }
}
