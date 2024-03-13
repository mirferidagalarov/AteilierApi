using Business.Abstract;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Entities.Concrete.DTOs.ProductDTOs;
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
        public IActionResult Add([FromForm] ProductToAddDTO productToAddDTO, IFormFile image)
        {
            var data = CloudinaryPost(image);
            productToAddDTO.ImagePath = data;
            var result = _productService.Add(productToAddDTO);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Edit([FromForm] ProductToUpdateDTO productToUpdateDTO, IFormFile image)
        {
            if (image != null)
            {
                var oldlink = productToUpdateDTO.ImagePath;
                CloudinaryDelete(oldlink);
                var data = CloudinaryPost(image);
                productToUpdateDTO.ImagePath = data;
            }

            var result = _productService.Update(productToUpdateDTO);
            return Ok(result);
        }   

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _productService.Delete(id);
            return Ok();
        }

        static string UploadImageAndGetPath(Cloudinary cloudinary, IFormFile image, string cloudinaryImagePath)
        {
            using (var stream = image.OpenReadStream())
            {
                cloudinaryImagePath = cloudinaryImagePath.TrimStart('/');

                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(image.FileName, stream),
                    PublicId = cloudinaryImagePath,
                };

                var uploadResult = cloudinary.Upload(uploadParams);

                return uploadResult.SecureUri.ToString();
            }
        }

        static string CloudinaryPost(IFormFile image)
        {
            IConfiguration configuration = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
              .Build();

            string cloudName = configuration["Password:CloudName"];
            string apiKey = configuration["Password:ApiKey"];
            string apiSecret = configuration["Password:ApiSecret"];
            string cloudinaryFolder = "Home/HomeBanner";

            var cloudinaryAccount = new Account(cloudName, apiKey, apiSecret);
            var cloudinary = new Cloudinary(cloudinaryAccount);

            try
            {
                string uniqueFilename = Guid.NewGuid().ToString("N");
                string cloudinaryImagePath = $"{cloudinaryFolder}/{uniqueFilename}";
                string link = $"https://res.cloudinary.com/{cloudName}/{cloudinaryImagePath}";
                var uploadResult = UploadImageAndGetPath(cloudinary, image, cloudinaryImagePath);
                return link;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        static string CloudinaryDelete(string image)
        {

            try
            {
                IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

                string cloudName = configuration["Password:CloudName"];
                string apiKey = configuration["Password:ApiKey"];
                string apiSecret = configuration["Password:ApiSecret"];

                var cloudinaryAccount = new Account(cloudName, apiKey, apiSecret);
                var cloudinary = new Cloudinary(cloudinaryAccount);

                var publicIds = new List<string>();
                publicIds.Add(image);

                DelResParams deleteParams = new DelResParams()
                {
                    PublicIds = publicIds
                };

                DelResResult result = cloudinary.DeleteResources(deleteParams);

                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return "Images deleted successfully.";
                }
                else
                {
                    return "Failed to delete images. Error: " + result.Error.Message;
                }
            }


            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
  