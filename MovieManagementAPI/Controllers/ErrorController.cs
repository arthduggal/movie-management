using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagementAPI.Controllers
{
    
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("Error")]
        public IActionResult Error()
        {
            var exceptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            return StatusCode(500, new { Error = "Something went wrong!!! Please contact admin." });
        }
    }
}
