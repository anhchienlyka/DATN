using DANTN.ApplicationLayer.Interface;
using DATN.Data.Viewmodel.ProductViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DATN.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var reponse = await _productService.GetAll();
            return Ok(reponse);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductById(int id)
        {
            var reponse = await _productService.GetById(id);
            return Ok(reponse);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductByCategoryId(int id)
        {
            var reponse = await _productService.GetProductByCategoryId(id);
            return Ok(reponse);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductByName(string name)
        {
            var reponse = await _productService.GetByName(name);
            return Ok(reponse);
        }

        [HttpGet]
        public async Task<IActionResult> GetIdPorductMax()
        {
            var reponse = await _productService.GetIdProductMax();
            return Ok(reponse);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductByView()
        {
            var reponse = await _productService.GetProductByView();
            return Ok(reponse);
        }

        [HttpGet]
        public async Task<IActionResult> GetFeaturedProduct()
        {
            var reponse = await _productService.GetFeaturedProduct();
            return Ok(reponse);
        }

        [HttpGet]
        public async Task<IActionResult> GetRecentProduct()
        {
            var reponse = await _productService.GetRecentProduct();
            return Ok(reponse);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var reponse = await _productService.Detele(id);
            return Ok(reponse);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(ProductUpdateVM product)
        {
            var reponse = await _productService.Update(product);
            return Ok(reponse);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductAddVM product)
        {
            var reponse = await _productService.Add(product);
            return Ok(reponse);
        }
    }
}