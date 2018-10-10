using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;



namespace CDB.DAL.Abstraction.Repositories

{

    public interface IRepository<TEntity> where TEntity : class

    {

        IEnumerable<TEntity> GetAll();



        Task<List<TEntity>> GetAllAsync(CancellationToken ct);



        TEntity Get(object Id);



        void Add(TEntity entity);



        void AddRange(IEnumerable<TEntity> entities);



        void Update(TEntity entity);



        void Remove(object Id);



        void Remove(TEntity entity);



        void RemoveRange(IEnumerable<TEntity> entities);

    }

}
