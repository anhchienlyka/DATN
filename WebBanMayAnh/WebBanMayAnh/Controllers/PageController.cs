using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBanMayAnh.DataContext;

namespace WebBanMayAnh.Controllers
{
    public class PageController : Controller
    {
        private readonly DATNContext _context;

        public PageController()
        {

        }
        public IActionResult Index(DATNContext _context)
        {
            return View();
        }

        [Route("/page/{Alias}", Name = "PageDetails")]
        public IActionResult Details(string Alias)
        {
            if (string.IsNullOrEmpty(Alias))
            {
                return RedirectToAction("Index","Home");
            }
            var pageDetail = _context.Pages.AsNoTracking().SingleOrDefault(x => x.Alias == Alias);
            if (pageDetail == null)
            {
                return RedirectToAction("Index","Home");
            }
            return View(pageDetail);
        }
    }
}
