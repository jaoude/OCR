using OCR.DAL.Abstraction.UnitOfWork;
using Microsoft.Extensions.Logging;
using OCR.BLL.Abstraction;
using OCR.BLL.Abstraction.Service;
using OCR.BLL.Dto.Request;
using OCR.Core.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OCR.BLL.Implementation.Service
{
    public class PageService : BaseService, IPageService
    {
        public PageService(IUnitOfWork uow, ILogger<PageService> logger, IModelMapHelper mapper) : base(uow, logger, mapper)
        {
        }

        public async Task UploadPages(List<PageUploadDto> pages, CancellationToken ct)
        {
            List<Page> pageEntities = new List<Page>();

            //foreach (PageUploadDto pageDto in pages)
            {
               ///* Page pageEntity = new Page();
               // pageEntity.IssuDate = pageDto.IssuDate;
               // pageEntity.IssueNumber = pageDto.IssueNumber;
               // pageEntity.PageNumber = pageDto.PageNumber;
               // pageEntity.FullText = File.ReadAllText(pageDto.FullText);
               // pageEntity.Image = File.ReadAllBytes(pageDto.Image);
               // pageEntities.Add(pageEntity);

                Page pageEntity = new Page();
                pageEntity.IssuDate = DateTime.Now;
                pageEntity.IssueNumber = 2223;
                pageEntity.PageNumber = 456;
                pageEntity.FullText = File.ReadAllText(@"C:\Dev\OCR\OCR.WebApi\wwwroot\images\Pages\4467.txt");
                pageEntity.Image = File.ReadAllBytes(@"C:\Dev\OCR\OCR.WebApi\wwwroot\images\Pages\4467.gif");
                pageEntities.Add(pageEntity);
            }

            _uow.Pages.AddRange(pageEntities);
            _uow.SaveChanges();
        }
    }
}
