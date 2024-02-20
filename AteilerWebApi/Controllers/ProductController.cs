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
        public async Task<IActionResult> Index()
        {
            var data =_productService.GetAll();
            return Ok(data);
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


        
    }
}
 