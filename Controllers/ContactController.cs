using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElmirProje.Contexts;
using ElmirProje.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElmirProje.Controllers
{
    [Authorize(Roles = "Admin,Member")]

    public class ContactController : Controller
    {
        private readonly AppDbContext _context;
        public ContactController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var contact = new Contact();
            return View(contact);
        }
        [HttpPost]
        public async Task<IActionResult> Index(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return View(contact);
            }

            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();


            return RedirectToAction("Index", "Contact");
        }
    }
}
