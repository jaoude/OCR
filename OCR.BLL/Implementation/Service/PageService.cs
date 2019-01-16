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
        private async Task<bool> UploadPage(string txtName, string imgName, int pageNumber, CancellationToken ct)
        {
            string path = @"C:\Dev\OCR\OCR.WebApi\wwwroot\images\Pages\";
            DateTime issueDate = Convert.ToDateTime("09/27/2018");
            int issueNumber = 42;
            bool result = false;
            if (!_uow.Pages.Get().Any(c => c.PageNumber == pageNumber))
            {
                _uow.Pages.Add(new Page()
                {
                    IssuDate = issueDate,
                    IssueNumber = issueNumber,
                    PageNumber = pageNumber,
                    FullText = File.ReadAllText(path + txtName),
                    Image = File.ReadAllBytes(path + imgName)
                });
                await _uow.SaveChangesAsync(ct);
                result = true;
            }
            return result;
        }
        public async Task<bool> UploadPages(List<PageUploadDto> pages, CancellationToken ct)
        {
            bool result =
                await UploadPage("4467.txt", "4467.gif", 4467, ct)
                || await UploadPage("4468.txt", "4468.gif", 4468, ct)
                || await UploadPage("4469.txt", "4469.gif", 4469, ct)
                || await UploadPage("4470.txt", "4470.gif", 4470, ct)
                || await UploadPage("4471.txt", "4471.gif", 4471, ct)
                || await UploadPage("4472.txt", "4472.gif", 4472, ct)
                || await UploadPage("4473.txt", "4473.gif", 4473, ct)
                || await UploadPage("4472.txt", "4472.gif", 4474, ct)
                || await UploadPage("4473.txt", "4473.gif", 4475, ct);
            return result;
        }
        public async Task<bool> UploadNewPage(int pagenumber, CancellationToken ct)
        {
            bool result = await UploadPage(pagenumber + ".txt", pagenumber + ".gif", pagenumber, ct);
            return result;
        }
        public async Task<byte[]> GetDummyImage(int imageId, CancellationToken ct)
        {
            Page page = await _uow.Pages.GetAsync(imageId, ct);
            if (page == null)
            {
                return null;
            }
            else
                return page.Image;
           
        }

        public async Task<List<Tuple<int, string>>> SearchForText(string text, CancellationToken ct)
        {
            return await _uow.Pages.GetDistinctByTextAsync(text, ct);
        }
    }
}
