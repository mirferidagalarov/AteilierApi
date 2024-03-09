using Business.Abstract;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Core.Helpers.Constant;
using Entities.Concrete.DTOs.PostDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entities.Concrete.DTOs.HomeBannerDTOs;

namespace AteilerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var data=_postService.GetAll().Data; 
            return Ok(data);
        }

        [HttpGet("id")]

        public IActionResult GetById(int id)
        {
            var result = _postService.GetById(id);
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
        public IActionResult Add([FromForm]PostToAddDTO postToAddDTO,IFormFile image)
        {
            var data = CloudinaryPost(image);
            postToAddDTO.ImagePath = data;
            var result = _postService.Add(postToAddDTO);
            return Ok(result);  
        }

        [HttpPut]

        public IActionResult Update([FromForm] PostToUpdateDTO postToUpdateDTO, IFormFile image)
        {
            if (image != null)
            {
                var oldlink = postToUpdateDTO.ImagePath;
                CloudinaryDelete(oldlink);
                var data = CloudinaryPost(image);
                postToUpdateDTO.ImagePath = data;
            }

            _postService.Update(postToUpdateDTO);
            return Ok(CommonOperationMessage.DataUpdateSuccesfly);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _postService.Delete(id);
            return Ok(CommonOperationMessage.DataDeletedSuccesfly);
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
