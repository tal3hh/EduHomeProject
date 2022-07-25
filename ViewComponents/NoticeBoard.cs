using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElmirProje.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace ElmirProje.ViewComponents
{
    public class NoticeBoard : ViewComponent
    {
        private readonly AppDbContext _context;
        public NoticeBoard(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var notice =  _context.NoticeBoards.OrderByDescending(x => x.Date).ToList();

            return View(notice);
        }
    }
}
