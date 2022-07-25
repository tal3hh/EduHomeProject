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
    public class BioTableController : Controller
    {
        readonly IUow _uow;
        public BioTableController(IUow uow)
        {
            _uow = uow;
        }

        public async Task<IActionResult> BioTableList()
        {
            var bioTable = await _uow.GetRepository<BioTable>().GetAllAsync();

            return View(bioTable);
        }


        public IActionResult Create()
        {
            var bioTable = new BioTable();
            return View(bioTable);
        }
        [HttpPost]
        public async Task<IActionResult> Create(BioTable bioTable)
        {
            if (!ModelState.IsValid)
            {
                return View(bioTable);
            }
            await _uow.GetRepository<BioTable>().CreateAsync(bioTable);

            return RedirectToAction("BioTableList", "BioTable", new { area = "Admin" });
        }

        public async Task<IActionResult> Update(int id)
        {
            
            var bioTable = await _uow.GetRepository<BioTable>().GetFindAsync(id);
            return View(bioTable);
        }
        [HttpPost]
        public IActionResult Update(BioTable bioTable)
        {
            if (!ModelState.IsValid)
            {
                return View(bioTable);
            }
            _uow.GetRepository<BioTable>().Update(bioTable);
            return RedirectToAction("BioTableList", "BioTable", new { area = "Admin" });
        }

        public IActionResult Delete(int id)
        {
            _uow.GetRepository<BioTable>().Remove(id);
            return RedirectToAction("BioTableList", "BioTable", new { area = "Admin" });
        }

        public async Task<IActionResult> Details(int id)
        {
            var bioTable = await _uow.GetRepository<BioTable>().GetFindAsync(id);
            return View(bioTable);
        }
    }
}
