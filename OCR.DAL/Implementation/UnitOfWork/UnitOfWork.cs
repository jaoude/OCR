﻿using OCR.DAL.DbContext;
using System;

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using CDB.DAL.Abstraction.UnitOfWork;

namespace CDB.DAL.Implementation.UnitOfWork

{

    public class UnitOfWork : IUnitOfWork

    {
        private readonly ApplicationDbContext _db;
        private readonly IServiceProvider _serviceProvider;
        public UnitOfWork(ApplicationDbContext db,
            IServiceProvider serviceProvider)
        {
            _db = db;
            _serviceProvider = serviceProvider;
        }
        public async Task<int> SaveChangesAsync(CancellationToken ct)
        {
            return await _db.SaveChangesAsync(ct);
        }
        public int SaveChanges()
        {
            return _db.SaveChanges();
        }
        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
