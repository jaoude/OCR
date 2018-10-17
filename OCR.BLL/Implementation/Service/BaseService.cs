using System;
using System.Collections.Generic;
using System.Text;
using OCR.DAL.Abstraction.UnitOfWork;
using Microsoft.Extensions.Logging;
using OCR.BLL.Abstraction;

namespace OCR.BLL.Implementation.Service
{
    public class BaseService : IBaseService
    {
        protected readonly IUnitOfWork _uow;
        protected readonly ILogger<BaseService> _logger;
        protected readonly IModelMapHelper _mapper;

        public BaseService(IUnitOfWork uow, ILogger<BaseService> logger, IModelMapHelper mapper)
        {
            _uow = uow;
            _logger = logger;
            _mapper = mapper;
        }
    }
}
