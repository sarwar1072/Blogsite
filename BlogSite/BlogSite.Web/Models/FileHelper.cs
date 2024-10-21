using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BlogSite.Web.Models
{
    public class FileHelper : IFileHelper
    {
        private readonly IWebHostEnvironment _env;

        public FileHelper(IWebHostEnvironment env)
        {
            _env = env;
        }

        private string GenerateFileName(string fileName)
        {
            string[] strName = fileName.Split('.');
            string strFileName = DateTime.Now.ToUniversalTime().ToString("yyyyMMdd\\THHmmssfff") + "." + strName[strName.Length - 1];
            return strFileName;
        }

        public  string UploadFile(IFormFile file)
        {
            var uploads = "";
            if (file.Name== "CoverPhotoUrl")
            {
                uploads = Path.Combine(_env.WebRootPath, "images");
            }
            else
            {
                uploads = Path.Combine(_env.WebRootPath, "ListOfImages");
            }

            bool exists = Directory.Exists(uploads);
            if (!exists)
                Directory.CreateDirectory(uploads);

            //saving file
            var fileName = GenerateFileName(file.FileName);
            var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create);
            file.CopyToAsync(fileStream);

            if(file.Name == "CoverPhotoUrl")
                return "/images/" + fileName;
            else
                return "/ListOfImages/" + fileName;

        }

        public void DeleteFile(string imageUrl)
        {
            // Delete existing file
            string filePath = Path.Combine(_env.WebRootPath, imageUrl.TrimStart('/'));
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }

}

