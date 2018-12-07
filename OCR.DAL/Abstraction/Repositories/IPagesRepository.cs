using OCR.DAL.Abstraction.Repositories;
using OCR.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OCR.DAL.Abstraction.Repositories
{
    public interface IPagesRepository : IRepository<Page>
    {
        Task<List<Tuple<int, string>>> GetDistinctByTextAsync(string searchText, CancellationToken ct);
    }
}
