using Business.Abstract;
using Core.Helpers.Constant;
using Entities.Concrete.DTOs.TagDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AteilerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITagService _tagService;
        public TagController(ITagService tagService)
        {
            _tagService=tagService; 
        }

        [HttpGet]
        public IActionResult GetAll()
        {
           var data=_tagService.GetAll().Data;
            return Ok(data);
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            var result= _tagService.GetById(id);
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
        public IActionResult Add(TagToAddDTO tagToAddDTO)
        {
            var result=_tagService.Add(tagToAddDTO);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update(TagToUpdateDTO tagToUpdateDTO)
        {
            var result=_tagService.Update(tagToUpdateDTO);
            return Ok(CommonOperationMessage.DataUpdateSuccesfly);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _tagService.Delete(id);
            return Ok(CommonOperationMessage.DataDeletedSuccesfly);
        }
    }
}
