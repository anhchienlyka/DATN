using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBanMayAnh.DataContext;
using WebBanMayAnh.Models;

namespace WebBanMayAnh.Controllers
{

    public class BlogController : Controller
    {
        private readonly DATNContext _context;
        public BlogController(DATNContext context)
        {
            _context = context;
        }
        [Route("blogs.html",Name ="Blog")]
        public IActionResult Index(int? page)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 10;
            var listPage = _context.Posts.AsNoTracking().OrderByDescending(x => x.PostID);
            PagedList<Post> models = new PagedList<Post>(listPage, pageNumber, pageSize);
            ViewBag.CurrentPage = pageNumber;
            return View(models);
        }
        //[Route("/tintuc/{Alias}-id.html", Name = "PostDetails")]
        public IActionResult Details(int? id)
        {
            var postDetail = _context.Posts.AsNoTracking().SingleOrDefault(x => x.PostID == id);
            if (postDetail==null)
            {
                return RedirectToAction("Index","Home");
            }
            var listBaiVietLq = _context.Posts.Where(x => x.Published == true && x.PostID == id).Take(3).OrderByDescending(x => x.CreatedDate).ToList();
            ViewBag.BaiVietLienQuan = listBaiVietLq;
            return View(postDetail);
        }
    }
}
