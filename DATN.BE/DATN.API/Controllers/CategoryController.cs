using DANTN.ApplicationLayer.Interface;
using DATN.Data.Viewmodel;
using DATN.InfrastructureLayer.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DATN.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var reponse = await _categoryService.GetAll();
            return Ok(reponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdCategory(int id)
        {
            var reponse = await _categoryService.GetById(id);
            return Ok(reponse);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var reponse = await _categoryService.Delete(id);
            return Ok(reponse);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(CategoryUpdateVM category)
        {
            var reponse = await _categoryService.Update(category);
            return Ok(reponse);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryAddVM category)
        {
           
            try
            {
                var reponse = await _categoryService.Add(category);
                return Ok(reponse);
            }
            catch (Exception e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, Messages.Error);
            }
        }

    }
}
