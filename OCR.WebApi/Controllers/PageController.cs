using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OCR.BLL.Abstraction;
using OCR.WebApi.Models;

namespace OCR.WebApi.Controllers
{
    [Route("[controller]/[action]")]
    public class PageController : BaseController<PageController>
    {
        public PageController(
               IBaseService baseService,
               ILogger<PageController> logger) : base(logger, baseService)
        {
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult> Index(CancellationToken ct)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return null;
                }
                catch (Exception e)
                {
                    _logger.LogError(e.Message);
                }
            }
            return null;

        }
    }
}
