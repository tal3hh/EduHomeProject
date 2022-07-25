using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElmirProje.Contexts;
using ElmirProje.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElmirProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class EventTeacherController : Controller
    {
        readonly AppDbContext _context;
        public EventTeacherController(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> EventTeacherList()
        {
            var list = await _context.EventTeachers.Include(x => x.Teacher).Include(x => x.Event).ToListAsync();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var teachers = await _context.Teachers.ToListAsync();

            var skills =await _context.Events.ToListAsync();

            var teacherskill = new EventTeacher();

            return View((teacherskill, teachers, skills));
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind(Prefix = "Item1")] EventTeacher teacherSkill)
        {

            await _context.EventTeachers.AddAsync(teacherSkill);
            await _context.SaveChangesAsync();

            return RedirectToAction("EventTeacherList", "EventTeacher", new { area = "Admin" });
        }

        public async Task<IActionResult> Update(int id)
        {
            var teachers = await _context.Teachers.ToListAsync();

            var skills = await _context.Events.ToListAsync();

            var teacherskill = await _context.EventTeachers.Include(x => x.Teacher).Include(x => x.Event).FirstOrDefaultAsync(x => x.Id == id);

            return View((teacherskill, teachers, skills));
        }
        [HttpPost]
        public IActionResult Update([Bind(Prefix = "Item1")] EventTeacher teacherSkill)
        {

            _context.EventTeachers.Update(teacherSkill);
            _context.SaveChanges();

            return RedirectToAction("EventTeacherList", "EventTeacher", new { area = "Admin" });
        }

        public IActionResult Delete(int id)
        {
            var teacherskill = _context.EventTeachers.Include(x => x.Teacher).Include(x => x.Event).FirstOrDefault(x => x.Id == id);
            _context.EventTeachers.Remove(teacherskill);
            _context.SaveChanges();

            return RedirectToAction("EventTeacherList", "EventTeacher", new { area = "Admin" });
        }

        public async Task<IActionResult> Details(int id)
        {
            var teacherskill = await _context.EventTeachers.Include(x => x.Teacher).Include(x => x.Event).FirstOrDefaultAsync(x => x.Id == id);

            return View(teacherskill);
        }
    }
}
