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
using OCR.BLL.Dto.Request;

namespace OCR.WebApi.Controllers
{
    [Route("[controller]/[action]")]
    public class AdminController : BaseController<PageController>
    {
        public AdminController(
               IBaseService baseService,
               ILogger<PageController> logger) : base(logger, baseService)
        {
        }
    }
}
