using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElmirProje.Contexts;
using ElmirProje.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElmirProje.ViewComponents
{
    public class Subscribe : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var subscribe = new Subscribee();

            return View(subscribe);
        }
    }
}
