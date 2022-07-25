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
    public class ServiceController : Controller
    {
        readonly IUow _uow;

        public ServiceController(IUow uow)
        {
            _uow = uow;
        }

        public async Task<IActionResult> ServiceList()
        {
            var servicelist = await _uow.GetRepository<Service>().GetAllAsync();

            return View(servicelist);
        }


        public IActionResult Create()
        {
            var service = new Service();
            return View(service);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Service service)
        {
            if (!ModelState.IsValid)
            {
                return View(service);
            }
            await _uow.GetRepository<Service>().CreateAsync(service);

            return RedirectToAction("ServiceList", "Service", new { area = "Admin" });
        }

        public async Task<IActionResult> Update(int id)
        {
            var service = await _uow.GetRepository<Service>().GetFindAsync(id);
            return View(service);
        }
        [HttpPost]
        public IActionResult Update(Service service)
        {
            if (!ModelState.IsValid)
            {
                return View(service);
            }
            _uow.GetRepository<Service>().Update(service);
            return RedirectToAction("ServiceList", "Service", new { area = "Admin" });
        }

        public IActionResult Delete(int id)
        {
            _uow.GetRepository<Service>().Remove(id);
            return RedirectToAction("ServiceList", "Service", new { area = "Admin" });
        }

        public async Task<IActionResult> Details(int id)
        {
            var service = await _uow.GetRepository<Service>().GetFindAsync(id);
            return View(service);
        }
    }
}
