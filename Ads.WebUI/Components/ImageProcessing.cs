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
        private const int MAX_PHOTO_SIZE = 1024000;
        private readonly IHostingEnvironment _hostingEnvironment;
        public ImageProcessing(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public static async Task<List<ImageDto>> ImageToBase64(List<IFormFile> pictures, int Id)
        {
            List<ImageDto> files = new List<ImageDto>();
            int i;
            for (i = 0; i < (pictures.Count < 9 ? pictures.Count : 9); ++i)
            {
                if ((pictures[i].Length > 0) && (pictures[i].Length < MAX_PHOTO_SIZE))
                {
                    ImageDto buf = new ImageDto()
                    {
                        AdvertId = Id,
                        Name = Path.GetFileName(pictures[i].FileName)
                    };
                    using (var ms = new MemoryStream())
                    {
                        await pictures[i].CopyToAsync(ms);
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
