using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Datester.Services
{
    public interface ICloudinaryMediaService
    {
        Task<string> UploadPhoto(byte[] photo);
    }
}
