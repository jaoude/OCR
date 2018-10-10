
using System;
using System.Threading;

using System.Threading.Tasks;



namespace CDB.DAL.Abstraction.UnitOfWork

{

    public interface IUnitOfWork : IDisposable

    {



        Task<int> SaveChangesAsync(CancellationToken ct);



        int SaveChanges();

    }

}