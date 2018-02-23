using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OpenBrisk.Gateway
{
    public class ProxyResult : ActionResult
    {
        private readonly HttpResponseMessage responseMessage;

        public ProxyResult(HttpResponseMessage responseMessage)
        {
            this.responseMessage = responseMessage;
        }

        public async override Task ExecuteResultAsync(ActionContext context)
        {
			context.HttpContext.Response.StatusCode = (int)this.responseMessage.StatusCode;

            foreach (KeyValuePair<string, IEnumerable<string>> header in this.responseMessage.Headers)
            {
                Console.WriteLine($"HEADER: {header.Key}:{header.Value.FirstOrDefault()}");
                context.HttpContext.Response.Headers[header.Key] = header.Value.ToArray();
            }

            foreach (KeyValuePair<string, IEnumerable<string>> header in this.responseMessage.Content.Headers)
            {
                Console.WriteLine($"HEADER: {header.Key}:{header.Value.FirstOrDefault()}");
                context.HttpContext.Response.Headers[header.Key] = header.Value.ToArray();
            }

            // SendAsync removes chunking from the response. This removes the header so it doesn't expect a chunked response.
            context.HttpContext.Response.Headers.Remove("transfer-encoding");

            // Write content body to original request body.
            using (Stream stream = await this.responseMessage.Content.ReadAsStreamAsync())
            {
                await stream.CopyToAsync(context.HttpContext.Response.Body, 81920, context.HttpContext.RequestAborted);
            }
        }
    }
}
