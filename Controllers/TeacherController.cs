using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElmirProje.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElmirProje.Controllers
{
    [Authorize(Roles = "Admin,Member")]

    public class TeacherController : Controller
    {
        private readonly AppDbContext _context;

        public TeacherController(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var teachers = await _context.Teachers.OrderByDescending(x=> x.Id).ToListAsync();
            return View(teachers);
        }


        public async Task<IActionResult> TeacherDetails(int id)
        {
            var teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.Id == id);

            var skills = await _context.TeacherSkills.Where(x => x.TeacherId == id).Include(x => x.Skill).ToListAsync();

            return View((teacher, skills));
        }
    }
}
