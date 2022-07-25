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
    public class TagTableController : Controller
    {
        readonly IUow _uow;
        public TagTableController(IUow uow)
        {
            _uow = uow;
        }

        public async Task<IActionResult> TagTableList()
        {
            var servicelist = await _uow.GetRepository<TagTable>().GetAllAsync();
            return View(servicelist);
        }


        public IActionResult Create()
        {
            var service = new TagTable();
            return View(service);
        }
        [HttpPost]
        public async Task<IActionResult> Create(TagTable service)
        {
            if (!ModelState.IsValid)
            {
                return View(service);
            }
            await _uow.GetRepository<TagTable>().CreateAsync(service);
            return RedirectToAction("TagTableList", "TagTable", new { area = "Admin" });
        }

        public async Task<IActionResult> Update(int id)
        {
            var service = await _uow.GetRepository<TagTable>().GetFindAsync(id);
            return View(service);
        }
        [HttpPost]
        public IActionResult Update(TagTable service)
        {
            if (!ModelState.IsValid)
            {
                return View(service);
            }
            _uow.GetRepository<TagTable>().Update(service);
            return RedirectToAction("TagTableList", "TagTable", new { area = "Admin" });
        }

        public IActionResult Delete(int id)
        {
            _uow.GetRepository<TagTable>().Remove(id);
            return RedirectToAction("TagTableList", "TagTable", new { area = "Admin" });
        }

        public async Task<IActionResult> Details(int id)
        {
            var service = await _uow.GetRepository<TagTable>().GetFindAsync(id);
            return View(service);
        }
    }
}
