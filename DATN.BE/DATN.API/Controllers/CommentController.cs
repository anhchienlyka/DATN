using DANTN.ApplicationLayer.Interface;
using DATN.Data.Viewmodel.Comment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllComment()
        {
            var reponse = await _commentService.GetAll();
            return Ok(reponse);
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CommentAddVM comment)
        {
            var reponse = await _commentService.Add(comment);
            return Ok(reponse);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateComment(CommentUpdateVM comment)
        {
            var reponse = await _commentService.Update(comment);
            return Ok(reponse);
        }

        [HttpDelete]
        public async Task<IActionResult> DeteleComment(int id)
        {
            var reponse = await _commentService.Delete(id);
            return Ok(reponse);
        }
    }
}
