using AutoMapper;
using OCR.BLL.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCR.BLL.Implementation
{
    public class ModelMapHelper : IModelMapHelper
    {
        private readonly IMapper _mapper;

        public ModelMapHelper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public TDestination Map<TDestination>(object source)
        {
            return _mapper.Map<TDestination>(source);
        }
    }
}
