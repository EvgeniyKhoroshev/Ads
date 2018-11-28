using Ads.CoreService.Contracts.Dto;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Ads.MVCClientApplication.Components
{
    public class ImageProcessing
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public ImageProcessing(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public static async Task<List<ImageDto>> ImageToBase64(List<IFormFile> pictures, int Id)
        {
            List<ImageDto> files = new List<ImageDto>();
            foreach (var s in pictures)
            {
                if (s.Length > 0)
                {
                    ImageDto buf = new ImageDto();
                    buf.AdvertId = Id;
                    buf.Name = Path.GetFileName(s.FileName);
                    using (var ms = new MemoryStream())
                    {
                        await s.CopyToAsync(ms);
                        var fileBytes = ms.ToArray();
                        buf.Content = Convert.ToBase64String(fileBytes);
                    }
                    files.Add(buf);
                }
            }
            return files;
        }
    }
}
