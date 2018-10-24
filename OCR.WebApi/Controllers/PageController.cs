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
using OCR.BLL.Abstraction.Service;
using OCR.BLL.Dto.Request;
using OCR.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
namespace OCR.WebApi.Controllers
{
    [Route("[controller]/[action]")]
    public class PageController : BaseController<PageController>
    {
        private readonly IPageService _pageService;
        public PageController(
            IPageService pageService,
               IBaseService baseService,
               ILogger<PageController> logger) : base(logger, baseService)
        {
            _pageService = pageService;
        }

       
        //[AllowAnonymous]
        [HttpGet]
        //public async Task<ActionResult> Upload(List<PageUploadDto> pageuploaddto, CancellationToken ct)
        public async Task<ActionResult> Upload(/*List<PageUploadDto> pageuploaddto, */CancellationToken ct)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _pageService.UploadPages(null, ct);
                }
                catch (Exception e)
                {
                    _logger.LogError(e.Message);
                }
            }
            return null;

        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

    }
}
