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
    public class NoticeBoardController : Controller
    {
        readonly IUow _uow;
        public NoticeBoardController(IUow uow)
        {
            _uow = uow;
        }

        public async Task<IActionResult> NoticeBoardList()
        {
            var servicelist = await _uow.GetRepository<NoticeBoard>().GetAllAsync();
            return View(servicelist);
        }
        
        public IActionResult Create()
        {
            var service = new NoticeBoard();
            return View(service);
        }
        [HttpPost]
        public async Task<IActionResult> Create(NoticeBoard service)
        {
            if (!ModelState.IsValid)
            {
                return View(service);
            }
            await _uow.GetRepository<NoticeBoard>().CreateAsync(service);

            return RedirectToAction("NoticeBoardList", "NoticeBoard", new { area = "Admin" });
        }

        public async Task<IActionResult> Update(int id)
        {
            var service = await _uow.GetRepository<NoticeBoard>().GetFindAsync(id);
            return View(service);
        }
        [HttpPost]
        public IActionResult Update(NoticeBoard service)
        {
            if (!ModelState.IsValid)
            {
                return View(service);
            }
            _uow.GetRepository<NoticeBoard>().Update(service);
            return RedirectToAction("NoticeBoardList", "NoticeBoard", new { area = "Admin" });
        }

        public IActionResult Delete(int id)
        {
            _uow.GetRepository<NoticeBoard>().Remove(id);
            return RedirectToAction("NoticeBoardList", "NoticeBoard", new { area = "Admin" });
        }

        public async Task<IActionResult> Details(int id)
        {
            var service = await _uow.GetRepository<NoticeBoard>().GetFindAsync(id);
            return View(service);
        }

    }
}
