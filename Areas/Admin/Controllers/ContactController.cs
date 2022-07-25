using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElmirProje.Contexts;
using ElmirProje.Models;
using ElmirProje.UniteOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElmirProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ContactController : Controller
    {
        readonly IUow _uow;
        readonly AppDbContext _context;
        public ContactController(IUow uow, AppDbContext context)
        {
            _uow = uow;
            _context = context;
        }



        public async Task<IActionResult> ContactList()
        {
            var contact = await _context.Contacts.OrderByDescending(x => x.Id).ToListAsync();

            return View(contact);
        }


        public IActionResult Create()
        {
            var contact = new Contact();
            return View(contact);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return View(contact);
            }
            await _uow.GetRepository<Contact>().CreateAsync(contact);

            return RedirectToAction("ContactList", "Contact", new { area = "Admin" });
        }

        public async Task<IActionResult> Update(int id)
        {
            var contact = await _uow.GetRepository<Contact>().GetFindAsync(id);
            return View(contact);
        }
        [HttpPost]
        public IActionResult Update(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return View(contact);
            }
            _uow.GetRepository<Contact>().Update(contact);
            return RedirectToAction("ContactList", "Contact", new { area = "Admin" });
        }

        public IActionResult Delete(int id)
        {
            _uow.GetRepository<Contact>().Remove(id);
            return RedirectToAction("ContactList", "Contact", new { area = "Admin" });
        }

        public async Task<IActionResult> Details(int id)
        {
            var contact = await _uow.GetRepository<Contact>().GetFindAsync(id);
            return View(contact);
        }
    }
}
