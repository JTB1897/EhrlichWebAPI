using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using EhrlichWebAPI.Contracts;
using EhrlichWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace EhrlichWebAPI.Controllers
{
    public class UploadImageController : BaseController<CloudinaryModel>
    {
        private readonly ICloudinaryRepository _cloudinaryRepository;
        public string Cloud_Name = "dzwjsorwi";
        public string API_Key = "338589468331215";
        public string API_Secret = "4akjN-oJ2FiMg1AbM356UAescaY";
        public Cloudinary _cloudinary;

        protected readonly IConfiguration _config;
        private readonly string SourceFolder;

        public UploadImageController(ICloudinaryRepository cloudinaryRepository, IConfiguration config) : base(cloudinaryRepository)
        {
            _cloudinaryRepository = cloudinaryRepository;
            _config = config;
            SourceFolder = _config.GetValue<string>("SourceSettings:SourceFolder");
        }

        [HttpPost("Upload")]
        public IActionResult UploadImage([FromBody] CloudinaryModel cloudinaryModel)
        {
           
            Account account = new Account(Cloud_Name, API_Key, API_Secret);
            _cloudinary = new Cloudinary(account);
            var sources = Directory.GetFiles(SourceFolder, "*").OrderBy(f => new FileInfo(f).Length).ToList();

            foreach (var source in sources)
            {

                var Params = new ImageUploadParams()
                {
                    File = new FileDescription(source.ToString()),
                };
                var res  = _cloudinary.Upload(Params);

                cloudinaryModel.Url = res.Url.ToString();
                cloudinaryModel.publicId = res.PublicId.ToString();
                _cloudinaryRepository.Add(cloudinaryModel);
            }
            return Ok();
        }
        [HttpDelete("PublicId")]
        public  IActionResult DeleteImage([FromBody] CloudinaryModel cloudinaryModel)
        {
            Account account = new Account(Cloud_Name, API_Key, API_Secret);
            _cloudinary = new Cloudinary(account);
            _cloudinary.DeleteResources(cloudinaryModel.publicId);
            _cloudinaryRepository.Delete(cloudinaryModel.Id);
            return Ok();
        }
        
    }
}
