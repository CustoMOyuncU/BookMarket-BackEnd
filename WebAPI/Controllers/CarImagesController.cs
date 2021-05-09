using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        public static IWebHostEnvironment _webHostEnvironment;
        IBookImageService _bookImageService;
        public CarImagesController(IWebHostEnvironment webHostEnvironment, IBookImageService bookImageService)
        {
            _webHostEnvironment = webHostEnvironment;
            _bookImageService = bookImageService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = ("Image"))] IFormFile file, [FromForm] BookImage bookImage)
        {
            var result = _bookImageService.Add(file, bookImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(BookImage bookImage)
        {
            var result = _bookImageService.Update(bookImage);
            if (result.Success)
            {
                return Ok(bookImage);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(BookImage bookImage)
        {
            var result = _bookImageService.Delete(bookImage);
            if (result.Success)
            {
                return Ok(bookImage);
            }
            return BadRequest(result);
        }

        [HttpGet("getcarimagebybookid")]
        public IActionResult GetCarImageByBookId(int id)
        {
            var result = _bookImageService.GetByBookId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _bookImageService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getfilebyid")]
        public IActionResult GetFileById(int id)
        {
            var result = _bookImageService.GetById(id);

            if (result.Success)
            {
                var f = System.IO.File.ReadAllBytes(result.Data.ImagePath);
                return File(f, "image/jpeg");
            }

            return BadRequest(result);
        }

    }
}
