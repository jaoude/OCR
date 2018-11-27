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
using System.Net.Mime;
using System.Net;

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


        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Upload(CancellationToken ct)
        {
            try
            {
                bool result = await _pageService.UploadPages(null, ct);
                if(result == true)
                    return Json(new { success = true, responseText = "Success!" });
                else
                    return Json(new { success = false, responseText = "No page were loaded - the db already contain these pages" });
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return Json(new { success = false, responseText = e.Message });
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult> GetDummyImage(int id, CancellationToken ct)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _pageService.GetDummyImage(id, ct);
                    var image = new FileStreamResult(new System.IO.MemoryStream(result.Result), "image/jpeg");
                    return image;
                }
                catch (Exception e)
                {
                    _logger.LogError(e.Message);
                }
            }
            return null;
        }

        [HttpPost]
        [AllowAnonymous]
        public /*List<Tuple<int, string>>*/ /*Task<ActionResult>*/ async Task<string> SearchForText(string search,CancellationToken ct)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return await _pageService.SearchForText(search, ct);
                    ////await Task.Delay(5000);
                    //string output = "<ul>";
                    //foreach (var c in result)
                    //{
                    //    output += "<li>" + c.Item2 + "</li>";
                    //}
                    //output += "</ul>";
                    //return (output);//StatusCode(205); 
                    ////return result;
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
