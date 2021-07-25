using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
           var result = _carImageService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("add")]
        public IActionResult Add([FromForm(Name =("Image"))] IFormFile file,[FromForm] CarImages carImages)
        {
           var result = _carImageService.Add(carImages,file);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("delete")]
        public IActionResult Delete([FromForm(Name =("id"))] int id)
        {
            var deleteCarImage = _carImageService.GetById(id).Data;
            var result = _carImageService.Delete(deleteCarImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPut("Update")]
        public IActionResult Update([FromForm] CarImages carImages, [FromForm(Name = ("Image"))] IFormFile file)
        {
            var result = _carImageService.Update(carImages,file);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
