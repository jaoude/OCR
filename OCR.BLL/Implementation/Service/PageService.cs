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
using System.Linq;

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
            Page pageEntity1 = new Page();
            pageEntity1.IssuDate = Convert.ToDateTime("09/27/2018");
            pageEntity1.IssueNumber = 42;
            pageEntity1.PageNumber = 4467;
            pageEntity1.FullText = File.ReadAllText(@"C:\Dev\OCR\OCR.WebApi\wwwroot\images\Pages\4467.txt");
            pageEntity1.Image = File.ReadAllBytes(@"C:\Dev\OCR\OCR.WebApi\wwwroot\images\Pages\4467.gif");
            pageEntities.Add(pageEntity1);

            Page pageEntity2 = new Page();
            pageEntity2.IssuDate = Convert.ToDateTime("09/27/2018");
            pageEntity2.IssueNumber = 42;
            pageEntity2.PageNumber = 4468;
            pageEntity2.FullText = File.ReadAllText(@"C:\Dev\OCR\OCR.WebApi\wwwroot\images\Pages\4468.txt");
            pageEntity2.Image = File.ReadAllBytes(@"C:\Dev\OCR\OCR.WebApi\wwwroot\images\Pages\4468.gif");
            pageEntities.Add(pageEntity2);

            Page pageEntity3 = new Page();
            pageEntity3.IssuDate = Convert.ToDateTime("09/27/2018");
            pageEntity3.IssueNumber = 42;
            pageEntity3.PageNumber = 4469;
            pageEntity3.FullText = File.ReadAllText(@"C:\Dev\OCR\OCR.WebApi\wwwroot\images\Pages\4469.txt");
            pageEntity3.Image = File.ReadAllBytes(@"C:\Dev\OCR\OCR.WebApi\wwwroot\images\Pages\4469.gif");
            pageEntities.Add(pageEntity3);

            Page pageEntity4 = new Page();
            pageEntity4.IssuDate = Convert.ToDateTime("09/27/2018");
            pageEntity4.IssueNumber = 42;
            pageEntity4.PageNumber = 4470;
            pageEntity4.FullText = File.ReadAllText(@"C:\Dev\OCR\OCR.WebApi\wwwroot\images\Pages\4470.txt");
            pageEntity4.Image = File.ReadAllBytes(@"C:\Dev\OCR\OCR.WebApi\wwwroot\images\Pages\4470.gif");
            pageEntities.Add(pageEntity4);

            Page pageEntity5 = new Page();
            pageEntity5.IssuDate = Convert.ToDateTime("09/27/2018");
            pageEntity5.IssueNumber = 42;
            pageEntity5.PageNumber = 4471;
            pageEntity5.FullText = File.ReadAllText(@"C:\Dev\OCR\OCR.WebApi\wwwroot\images\Pages\4471.txt");
            pageEntity5.Image = File.ReadAllBytes(@"C:\Dev\OCR\OCR.WebApi\wwwroot\images\Pages\4471.gif");
            pageEntities.Add(pageEntity5);

            Page pageEntity6 = new Page();
            pageEntity6.IssuDate = Convert.ToDateTime("09/27/2018");
            pageEntity6.IssueNumber = 42;
            pageEntity6.PageNumber = 4472;
            pageEntity6.FullText = File.ReadAllText(@"C:\Dev\OCR\OCR.WebApi\wwwroot\images\Pages\4472.txt");
            pageEntity6.Image = File.ReadAllBytes(@"C:\Dev\OCR\OCR.WebApi\wwwroot\images\Pages\4472.gif");
            pageEntities.Add(pageEntity6);

            Page pageEntity7 = new Page();
            pageEntity7.IssuDate = Convert.ToDateTime("09/27/2018");
            pageEntity7.IssueNumber = 42;
            pageEntity7.PageNumber = 4473;
            pageEntity7.FullText = File.ReadAllText(@"C:\Dev\OCR\OCR.WebApi\wwwroot\images\Pages\4473.txt");
            pageEntity7.Image = File.ReadAllBytes(@"C:\Dev\OCR\OCR.WebApi\wwwroot\images\Pages\4473.gif");
            pageEntities.Add(pageEntity7);

            Page pageEntity8 = new Page();
            pageEntity8.IssuDate = Convert.ToDateTime("09/27/2018");
            pageEntity8.IssueNumber = 42;
            pageEntity8.PageNumber = 4474;
            pageEntity8.FullText = File.ReadAllText(@"C:\Dev\OCR\OCR.WebApi\wwwroot\images\Pages\4474.txt");
            pageEntity8.Image = File.ReadAllBytes(@"C:\Dev\OCR\OCR.WebApi\wwwroot\images\Pages\4474.gif");
            pageEntities.Add(pageEntity8);

            Page pageEntity9 = new Page();
            pageEntity9.IssuDate = Convert.ToDateTime("09/27/2018");
            pageEntity9.IssueNumber = 42;
            pageEntity9.PageNumber = 4475;
            pageEntity9.FullText = File.ReadAllText(@"C:\Dev\OCR\OCR.WebApi\wwwroot\images\Pages\4475.txt");
            pageEntity9.Image = File.ReadAllBytes(@"C:\Dev\OCR\OCR.WebApi\wwwroot\images\Pages\4475.gif");
            pageEntities.Add(pageEntity9);


            _uow.Pages.AddRange(pageEntities);
            _uow.SaveChanges();
        }
        public async Task<byte[]> GetDummyImage(int imageId, CancellationToken ct)
        {
            byte[] imageData = _uow.Pages.Get(imageId).Image;
            return imageData;
        }
        public List<Tuple<int, string>> SearchForText(string text, CancellationToken ct)
        {
            return _uow.Pages.Get().Where(pg => pg.FullText.Contains(text)).
                Select(res => new Tuple<int, string>(res.PageNumber, res.FullText.Substring(text[0]-10,10))).ToList();
        }
    }
}
