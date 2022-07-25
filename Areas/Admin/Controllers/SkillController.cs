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
    public class SkillController : Controller
    {
        readonly IUow _uow;
        public SkillController(IUow uow)
        {
            _uow = uow;
        }

        public async Task<IActionResult> SkillList()
        {
            var servicelist = await _uow.GetRepository<Skill>().GetAllAsync();

            return View(servicelist);
        }


        public IActionResult Create()
        {
            var service = new Skill();
            return View(service);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Skill service)
        {
            if (!ModelState.IsValid)
            {
                return View(service);
            }
            await _uow.GetRepository<Skill>().CreateAsync(service);

            return RedirectToAction("SkillList", "Skill", new { area = "Admin" });
        }

        public async Task<IActionResult> Update(int id)
        {
            var service = await _uow.GetRepository<Skill>().GetFindAsync(id);
            return View(service);
        }
        [HttpPost]
        public IActionResult Update(Skill service)
        {
            if (!ModelState.IsValid)
            {
                return View(service);
            }
            _uow.GetRepository<Skill>().Update(service);
            return RedirectToAction("SkillList", "Skill", new { area = "Admin" });
        }

        public IActionResult Delete(int id)
        {
            _uow.GetRepository<Skill>().Remove(id);
            return RedirectToAction("SkillList", "Skill", new { area = "Admin" });
        }

        public async Task<IActionResult> Details(int id)
        {
            var service = await _uow.GetRepository<Skill>().GetFindAsync(id);
            return View(service);
        }
    }
}
