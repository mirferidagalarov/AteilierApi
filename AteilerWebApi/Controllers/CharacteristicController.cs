using Business.Abstract;
using Business.Concrete;
using DataAccess.Configuration;
using Entities.Concrete.DTOs.CharacteristicDTOs;
using Entities.Concrete.DTOs.ColorDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AteilerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacteristicController : ControllerBase
    {
        private readonly ICharacteristicService _characteristicService;
        public CharacteristicController(ICharacteristicService characteristicService)
        {
            _characteristicService = characteristicService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _characteristicService.GetAll().Data;
            return Ok(data);
        }

        [HttpGet("id")]
        public IActionResult GetId(int id)
        {
            var result = _characteristicService.GetById(id);

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
        public IActionResult Add(CharacteristicAddDTO characteristicAddDTO)
        {
            _characteristicService.Add(characteristicAddDTO);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(CharacteristicUpdateDTO  characteristicUpdateDTO)
        {
            _characteristicService.Update(characteristicUpdateDTO);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _characteristicService.Delete(id);
            return Ok();

        }
    }
}
