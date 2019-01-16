using OCR.DAL.Abstraction.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OCR.DAL.Abstraction.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IPagesRepository Pages { get; }
        Task<int> SaveChangesAsync(CancellationToken ct);
         int SaveChanges();
    }
}