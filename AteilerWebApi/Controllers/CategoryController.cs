using Business.Abstract;
using Business.Concrete;
using Entities.Concrete.DTOs.CategoryDTOs;
using Entities.Concrete.DTOs.ColorDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AteilerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _categoryService.GetAll().Data;
            return Ok(data);
        }

        [HttpGet("id")]
        public IActionResult GetId(int id)
        {
            var result = _categoryService.GetById(id);

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
        public IActionResult Add(CategoryToAddDTO  categoryToAddDTO)
        {
            var result = _categoryService.Add(categoryToAddDTO);
            if (result.Success)
            {

            return Ok(result);
            }

            else
            {
             return  BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Update(CategoryToUpdateDTO  categoryToUpdateDTO)
        {
            var result = _categoryService.Update(categoryToUpdateDTO);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _categoryService.Delete(id);
            return Ok();
        }
        }
    }
