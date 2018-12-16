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

namespace OCR.DAL.Implementation.Repositories
{
    public class PagesRepository : Repository<Page>  , IPagesRepository
    {
        public PagesRepository(ApplicationDbContext _db) : base(_db)
        {
           
        }

        public async Task<Page> GetAsync(int id, CancellationToken ct)
        {
            return await _db.Set<Page>().FirstOrDefaultAsync(c => c.PageNumber == id, ct);
        }
    }
}
