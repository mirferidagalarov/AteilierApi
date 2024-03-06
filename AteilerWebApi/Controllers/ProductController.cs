using Business.Abstract;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace AteilerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
                _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data =_productService.GetAll().Data;
            return Ok(data);
        }

        [HttpGet("id")]
        public IActionResult GetId(int id)
        {
            var result = _productService.Get(id);
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
        public  IActionResult Add(Product product)
        {
           
             _productService.Add(product);
            return Ok();    
        }

        [HttpPut]
        public IActionResult Edit(Product product)
        {
            
            _productService.Update(product);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _productService.Delete(id);
            return Ok();
        }


        
    }
}
  