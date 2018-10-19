using OCR.DAL.Implementation.Repositories;
using OCR.Core.Model;
using OCR.DAL.DbContext;
using System;
using System.Collections.Generic;
using System.Text;
using OCR.DAL.Abstraction.Repositories;

namespace OCR.DAL.Implementation.Repositories
{
    public class PagesRepository : Repository<Page>  , IPagesRepository
    {
        public PagesRepository(ApplicationDbContext _db) : base(_db)
        {

        }
    }
}
