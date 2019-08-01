using System;
using System.Collections.Generic;
using System.Text;

namespace Datester.Services
{
    using System.IO;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc.Formatters;
    using Microsoft.Net.Http.Headers;

    public class BinaryInputFormatter : InputFormatter
    {
        const string binaryContentType = "image/jpeg";
        const int bufferLength = 16384;

        public BinaryInputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse(binaryContentType));
        }

        public async override Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context)
        {
            using (MemoryStream ms = new MemoryStream(bufferLength))
            {
                await context.HttpContext.Request.Body.CopyToAsync(ms);
                object result = ms.ToArray();
                return await InputFormatterResult.SuccessAsync(result);
            }
        }

        protected override bool CanReadType(Type type)
        {
            if (type == typeof(byte[]))
                return true;
            else
                return false;
        }
    }
}
