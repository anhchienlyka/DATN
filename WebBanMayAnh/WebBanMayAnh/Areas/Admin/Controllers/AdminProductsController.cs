using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using WebBanMayAnh.DataContext;
using WebBanMayAnh.Helpper;
using WebBanMayAnh.Models;

namespace WebBanMayAnh.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminProductsController : Controller
    {
        private readonly DATNContext _context;
        private INotyfService _notyfService;
        public AdminProductsController(DATNContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        // GET: Admin/AdminProducts
        public ActionResult Index(int? page)
        {
            ViewData["DanhMuc"] = new SelectList(_context.Categories, "CatID", "CatName");
            ViewData["NhaCungCap"] = new SelectList(_context.Categories, "SupplierID", "SupplierName");
            List<SelectListItem> lsStatus = new List<SelectListItem>();
            lsStatus.Add(new SelectListItem() { Text = "Active", Value = "1" });
            lsStatus.Add(new SelectListItem() { Text = "Block", Value = "0" });
            ViewData["lsStatus"] = lsStatus;
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 10;
            var listProduct = _context.Products.AsNoTracking().Include(x => x.Category).Include(x => x.Supplier).OrderByDescending(x => x.ProductID);
            PagedList<Product> models = new PagedList<Product>(listProduct, pageNumber, pageSize);
            ViewBag.CurrentPage = pageNumber;
            return View(models);
        }

        // GET: Admin/AdminProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category).Include(x => x.Supplier)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Admin/AdminProducts/Create
        public IActionResult Create()
        {
            ViewData["NhaCungCap"] = new SelectList(_context.Suppliers, "SupplierID", "SupplierName");
            ViewData["DanhMuc"] = new SelectList(_context.Categories, "CatID", "CatName");
            return View();
        }

        // POST: Admin/AdminProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductID,ProductName,ShortDesc,Description,CatID,Price,Discount,Inventory,Insurance,Accessory,Sensor,Thumb,Screen,ISO,ShutterSpeed,DateCreated,DateModified,SupplierID,Active,Tags,Alias,MetaDesc,MetaKey")] Product product, IFormFile fThumb)
        {

            if (ModelState.IsValid)
            {
                product.ProductName = Utilities.ToTitleCase(product.ProductName);
                product.DateCreated = DateTime.Now;
                product.DateModified = null;
                product.Active = true;
                if (fThumb != null)
                {
                    string extension = Path.GetExtension(fThumb.FileName);
                    string image = Utilities.SEOUrl(product.ProductName) + extension;
                    product.Thumb = await Utilities.UploadFile(fThumb, @"product", image.ToLower());
                }
                if (string.IsNullOrEmpty(product.Thumb)) product.Thumb = "default.jpg";
                product.Alias = Utilities.SEOUrl(product.ProductName);

                _context.Add(product);
                await _context.SaveChangesAsync();
                _notyfService.Success("Tạo mới thành công");
                return RedirectToAction(nameof(Index));
            }
            ViewData["NhaCungCap"] = new SelectList(_context.Suppliers, "SupplierID", "SupplierName");
            ViewData["DanhMuc"] = new SelectList(_context.Categories, "CatID", "CatName", product.CatID);
            return View(product);
        }

        // GET: Admin/AdminProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["NhaCungCap"] = new SelectList(_context.Suppliers, "SupplierID", "SupplierName");
            ViewData["DanhMuc"] = new SelectList(_context.Categories, "CatID", "CatName", product.CatID);
            return View(product);
        }

        // POST: Admin/AdminProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductID,ProductName,ShortDesc,Description,CatID,Price,Discount,Inventory,Insurance,Accessory,Sensor,Thumb,Screen,ISO,ShutterSpeed,DateCreated,DateModified,SupplierID,Active,Tags,Alias,MetaDesc,MetaKey")] Product product, IFormFile fThumb)
        {
            if (id != product.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    product.ProductName = Utilities.ToTitleCase(product.ProductName);
                    product.DateModified = DateTime.Now;
                    if (fThumb != null)
                    {
                        string extension = Path.GetExtension(fThumb.FileName);
                        string image = Utilities.SEOUrl(product.ProductName) + extension;
                        product.Thumb = await Utilities.UploadFile(fThumb, @"product", image.ToLower());
                    }
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                    _notyfService.Success("Chỉnh sửa thành công");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["NhaCungCap"] = new SelectList(_context.Suppliers, "SupplierID", "SupplierName");
            ViewData["DanhMuc"] = new SelectList(_context.Categories, "CatID", "CatName", product.CatID);
            return View(product);
        }

        // GET: Admin/AdminProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Admin/AdminProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            _notyfService.Success("Xóa thành công");
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductID == id);
        }
    }
}
