using OCR.DAL.Abstraction.Repositories;
using OCR.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace OCR.DAL.Abstraction.Repositories
{
    public interface IPagesRepository : IRepository<Page>
    {
        Task<Page> GetAsync(int id, CancellationToken ct);
        Task<List<Tuple<int, string>>> GetDistinctByTextAsync(string searchText, CancellationToken ct);
    }

}
