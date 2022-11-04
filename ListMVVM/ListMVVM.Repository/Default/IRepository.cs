using System.Collections.Generic;

namespace ListMVVM.Repository.Default
{
    public interface IRepository<TEntity>
    {
        IList<TEntity> FindAll();
        TEntity SaveOrUpdate(TEntity entity);
        void Delete(TEntity entity);
    }
}
