using OCR.DAL.Implementation.Repositories;
using OCR.Core.Model;
using OCR.DAL.DbContext;
using System;
using System.Collections.Generic;
using System.Text;
using OCR.DAL.Abstraction.Repositories;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace OCR.DAL.Implementation.Repositories
{
    public class PagesRepository : Repository<Page>  , IPagesRepository
    {
        public PagesRepository(ApplicationDbContext _db) : base(_db)
        {
           
        }

        public async Task<List<Tuple<int, string>>> GetDistinctByTextAsync(string searchText, CancellationToken ct)
        {
            List<Tuple<int, string>> result = new List<Tuple<int, string>>();
            var arabic = Encoding.GetEncoding(1256);

            foreach (Page page in _db.Set<Page>())
            {
                int index = -1;
                string fullText = page.FullText.Replace("\r\n", " ");
                if ((index = fullText.IndexOf(searchText, StringComparison.CurrentCultureIgnoreCase)) != -1)
                {
                    int len = 100;
                    int fullTextLen = fullText.Length;
                    int lowerBoundary = Math.Max(index - (len / 2), 0);
                    int upperBoundary = Math.Min(index + len, fullTextLen) - index;
                    try
                    {
                        string text = fullText.Substring(lowerBoundary, len);
                        int a = text.Length;
                        result.Add(new Tuple<int, string>(page.PageNumber, text));
                    }
                    catch (Exception e)
                    {
                    }
                }
            }
            return result.ToList();
        }

        public async Task<Page> GetAsync(int id, CancellationToken ct)
        {
            return await _db.Set<Page>().FirstOrDefaultAsync(c => c.PageNumber == id, ct);
        }
    }
}
