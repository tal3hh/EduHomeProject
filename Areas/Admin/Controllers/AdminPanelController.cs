using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElmirProje.UniteOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElmirProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class AdminPanelController : Controller
    {
        readonly IUow _uow;
        public AdminPanelController(IUow uow)
        {
            _uow = uow;
        }


        public IActionResult Index()
        {
            return View();
        }

        
    }
}
