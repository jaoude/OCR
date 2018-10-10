using System;
using System.Collections.Generic;
using System.Text;

namespace OCR.BLL.Abstraction
{
    public interface IModelMapHelper
    {
        TDestination Map<TDestination>(object source);
    }
}
