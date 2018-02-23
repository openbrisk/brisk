using System.Net.Http;
using Microsoft.AspNetCore.Mvc;

namespace OpenBrisk.Gateway
{
    public static class ControllerExtensions 
    {
        public static IActionResult Proxy(this Controller controller, HttpResponseMessage response)
        {
            return new ProxyResult(response);
        }
    }
}
