using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Datester.Services
{
    public class CloudinaryMediaService : ICloudinaryMediaService
    {
        private readonly Cloudinary cloudinary;

        public CloudinaryMediaService(IConfiguration configuration)
        {
            var account = new Account(
                configuration["AppSettings:Cloudinary:Cloud"],
                configuration["AppSettings:Cloudinary:ApiKey"],
                configuration["AppSettings:Cloudinary:ApiSecret"]
                );

            this.cloudinary = new Cloudinary(account);
        }

        public async Task<string> UploadPhoto (byte[] photo)
        {
            using (var stream = new MemoryStream(photo))
            {

                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription("Photo", stream),
                    Transformation = new Transformation().Width("900").Height("900").Crop("thumb").Gravity("face")
                };

                var uploadResult = await cloudinary.UploadAsync(uploadParams);
                return uploadResult.SecureUri.AbsoluteUri;
            }
        }
    }
}
