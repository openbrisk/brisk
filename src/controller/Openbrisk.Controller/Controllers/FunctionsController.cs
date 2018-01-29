using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Openbrisk.Controller.Controllers
{
    [Route("controller/v1")]
    public class FunctionsController : Controller
    {
        [HttpGet("functions")]
        public Task<IActionResult> GetFunctions() 
        {
            return this.Json(null);
        }
    }
}
