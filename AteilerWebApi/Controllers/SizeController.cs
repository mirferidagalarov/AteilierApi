using Business.Abstract;
using Core.Helpers.Constant;
using Core.Helpers.Result.Concrete;
using Entities.Concrete.DTOs.SizeDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AteilerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizeController : ControllerBase
    {
        private readonly ISizeService _sizeService;
        public SizeController(ISizeService sizeService)
        {
            _sizeService = sizeService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _sizeService.GetAll().Data;
            return Ok(data);
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            var result = _sizeService.GetById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            else
            {
                return BadRequest();    
            }
        }

        [HttpPost]
        public IActionResult Add(SizeToAddDTO sizeToUpdateDTO)
        {
            var result = _sizeService.Add(sizeToUpdateDTO);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update(SizeToUpdateDTO sizeToUpdateDTO)
        {
            _sizeService.Update(sizeToUpdateDTO);
            return Ok(CommonOperationMessage.DataUpdateSuccesfly);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _sizeService.Delete(id);
            return Ok(CommonOperationMessage.DataDeletedSuccesfly);
        }
        
    }
}
