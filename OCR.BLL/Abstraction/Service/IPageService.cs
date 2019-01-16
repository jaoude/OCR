using OCR.BLL.Dto.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OCR.BLL.Abstraction.Service
{
    public interface IPageService
    {
        Task <bool> UploadPages(List<PageUploadDto> pages, CancellationToken ct);
        Task<bool> UploadNewPage(int pagenumber, CancellationToken ct);

        Task<byte[]> GetDummyImage(int imageId, CancellationToken ct);
        Task<List<Tuple<int, string>>> SearchForText(string text, CancellationToken ct);

    }
}
