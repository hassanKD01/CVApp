using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace CVApp.Services
{
    public class ImageServices
    {
        private readonly IWebHostEnvironment _hostingEnv;

        public ImageServices(IWebHostEnvironment hostingEnv)
        {
            _hostingEnv = hostingEnv;
        }
        
        public async Task<string> SavePicture(IFormFile formFile)
        {
            
            var fileName = GetUniqueFileName( formFile.FileName);
            
            var filePath = Path.Combine(_hostingEnv.WebRootPath, "images\\", fileName);
            var thumbPath = Path.Combine(_hostingEnv.WebRootPath, "images\\thumbnails\\", fileName);

            using (var fileSteam = new FileStream(filePath, FileMode.Create))
            {
                await formFile.CopyToAsync(fileSteam);
                fileSteam.Close();
            }

            Image image = Image.FromFile("wwwroot\\images\\" + fileName);
            Image thumb = image.GetThumbnailImage(120, 120, () => false, IntPtr.Zero);

                thumb.Save(thumbPath,System.Drawing.Imaging.ImageFormat.Jpeg);

            return fileName;
        }

        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }
    }
}
