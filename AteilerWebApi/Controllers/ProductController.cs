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
        public  IActionResult AddContact(Product product)
        {
            var products = new Product()
            {
                ID = product.ID,
                Name = product.Name,
                Price= product.Price,
                Raiting= product.Raiting,
                Description= product.Description,
                ImagePath= product.ImagePath,
                IsFeatured= product.IsFeatured,
                IsTrending= product.IsTrending,
                CategoryId= product.CategoryId,
            };
             _productService.Add(products);
            return Ok(products);    
        }
    }
}
 