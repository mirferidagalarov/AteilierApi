using Business.Abstract;
using Entities.Concrete.DTOs.ColorDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AteilerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly IColorService _colorService;
        public ColorController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _colorService.GetAll().Data;
            return Ok(data);
        }

        [HttpGet("id")]
        public IActionResult GetId(int id)
        {
            var result = _colorService.GetById(id);

            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                BadRequest();
            }
            return Ok();
        }
        [HttpPost]
        public IActionResult Add(ColorToAddDTO colorToAddDTO)
        {
            _colorService.Add(colorToAddDTO);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(ColorToUpdateDTO colorToUpdateDTO)
        {
            _colorService.Update(colorToUpdateDTO);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _colorService.Delete(id);
            return Ok();

        }
    }
}
