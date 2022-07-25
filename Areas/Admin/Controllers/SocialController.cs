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
    public class SocialController : Controller
    {
        readonly IUow _uow;
        public SocialController(IUow uow)
        {
            _uow = uow;
        }

        public async Task<IActionResult> SocialList()
        {
            var servicelist = await _uow.GetRepository<Social>().GetAllAsync();

            return View(servicelist);
        }


        public IActionResult Create()
        {
            var service = new Social();
            return View(service);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Social service)
        {
            if (!ModelState.IsValid)
            {
                return View(service);
            }
            await _uow.GetRepository<Social>().CreateAsync(service);

            return RedirectToAction("SocialList", "Social", new { area = "Admin" });
        }

        public async Task<IActionResult> Update(int id)
        {
            var service = await _uow.GetRepository<Social>().GetFindAsync(id);
            return View(service);
        }
        [HttpPost]
        public IActionResult Update(Social service)
        {
            if (!ModelState.IsValid)
            {
                return View(service);
            }
            _uow.GetRepository<Social>().Update(service);
            return RedirectToAction("SocialList", "Social", new { area = "Admin" });
        }

        public IActionResult Delete(int id)
        {
            _uow.GetRepository<Social>().Remove(id);
            return RedirectToAction("SocialList", "Social", new { area = "Admin" });
        }

        public async Task<IActionResult> Details(int id)
        {
            var service = await _uow.GetRepository<Social>().GetFindAsync(id);
            return View(service);
        }
    }
}
