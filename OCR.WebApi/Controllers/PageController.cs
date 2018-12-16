using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OCR.BLL.Abstraction;
using OCR.BLL.Abstraction.Service;

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
                    var result =  _pageService.GetDummyImage(id, ct).Result;
                    if (result == null)
                    {
                        return null;// Content("<html>The page your are requesting is not available</html>");
                    }
                    var image = new FileStreamResult(new System.IO.MemoryStream(result), "image/jpeg");
                    return image;
                }
                catch (Exception e)
                {
                    //return await GetDummyImage(id + 1, ct);
                    _logger.LogError(e.Message);
                }
            }
            return null;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> SearchForText(string search,CancellationToken ct)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    List<Tuple<int, string>> result = await _pageService.SearchForText(search, ct);
                    if (result != null)
                    {
                        string output = "";
                        foreach (var c in result)
                        {
                            output += "<option id=" + c.Item1 + ">" + c.Item2 + "</option>";
                        }
                        return Json(new { success = true, responseText = output, size=result.Count});
                    }
                    return Json(new { success = false, responseText = "couldn't search for text" });
                }
                catch (Exception e)
                {
                    _logger.LogError(e.Message);
                    return Json(new { success = false, responseText = "" });
                }
            }
            return null;
        }
    }
}
