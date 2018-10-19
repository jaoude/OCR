using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OCR.BLL.Abstraction;

namespace OCR.WebApi.Controllers
{
    [Authorize]
    public class BaseController<T> : Controller
    {
        protected readonly ILogger<T> _logger;
        protected readonly IBaseService _baseEngine;

        public BaseController(ILogger<T> logger, IBaseService baseEngine)
        {
            _logger = logger;
            _baseEngine = baseEngine;
        }

    }
}