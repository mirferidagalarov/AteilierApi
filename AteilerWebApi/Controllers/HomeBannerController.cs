using Business.Abstract;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Core.Helpers.Result.Concrete;
using Entities.Concrete.DTOs.HomeBannerDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;
using static System.Net.Mime.MediaTypeNames;

namespace AteilerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeBannerController : ControllerBase
    {
        private readonly IHomeBannerService _homeBannerService;
        public HomeBannerController(IHomeBannerService homeBannerService)
        {
            _homeBannerService = homeBannerService; 
        }
        [HttpGet]
        public IActionResult GetAll()
        {
          var data=_homeBannerService.GetAll().Data;
          return Ok(data);

        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            var result=_homeBannerService.GetById(id);
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
        public IActionResult Add([FromForm]HomeBannerAddDTO homeBannerAddDTO,IFormFile image)
        {
            var data = CloudinaryPost(image);
            homeBannerAddDTO.ImagePath = data;
            _homeBannerService.Add(homeBannerAddDTO);
            return Ok();
        }


        [HttpPut]
        public IActionResult Update([FromForm]HomeBannerUpdateDTO homeBannerUpdateDTO, IFormFile image)
        {
            if (image != null)
            {
                var oldlink = homeBannerUpdateDTO.ImagePath;
                CloudinaryDelete(oldlink);
                var data = CloudinaryPost(image);
                homeBannerUpdateDTO.ImagePath = data;
            }

            _homeBannerService.Update(homeBannerUpdateDTO);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _homeBannerService.Delete(id);
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
