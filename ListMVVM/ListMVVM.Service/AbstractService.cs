using ListMVVM.Repository.Default;
using System.Collections.Generic;

namespace ListMVVM.Service
{
    public class AbstractService<TEntity>
    {
        private readonly IRepository<TEntity> repository;

        protected AbstractService(IRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        protected IRepository<TEntity> Repository => repository;

        public virtual IList<TEntity> FindAll()
        {
            return Repository.FindAll();
        }

        public virtual void SaveOrUpdate(TEntity entity)
        {
            Repository.SaveOrUpdate(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            Repository.Delete(entity);
        }
    }
}
