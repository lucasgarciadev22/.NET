using NHibernate;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ListMVVM.Repository.Default
{

    public class AbstractRepository<TEntity> : IRepository<TEntity>
    {
        private static Type _persistentType = typeof(TEntity);

        protected ISession Session
        {
            get { return NHibernateHelper.GetCurrentSession(); }
        }

        public virtual TEntity FindByID(int id)
        {
            return ExecuteCommand(MethodBase.GetCurrentMethod(), delegate (ISession session)
            {
                ICriteria criteria = Session.CreateCriteria(_persistentType);
                TEntity entity = session.Get<TEntity>(id);
                return entity;
            });

        }

        public virtual TEntity FindByListID(int[] id)
        {
            return ExecuteCommand(MethodBase.GetCurrentMethod(), delegate (ISession session)
            {
                ICriteria criteria = Session.CreateCriteria(_persistentType);
                TEntity entity = session.Get<TEntity>(id);
                return entity;
            });

        }

        public virtual IList<TEntity> FindAll()
        {
            return ExecuteCommand(MethodBase.GetCurrentMethod(), delegate (ISession session)
            {
                ICriteria criteria = Session.CreateCriteria(_persistentType);
                IList<TEntity> list = criteria.List<TEntity>();
                return list;
            });
        }

        public virtual void Delete(TEntity entity)
        {
            ExecuteCommand(MethodBase.GetCurrentMethod(), delegate (ISession session)
            {
                session.Delete(entity);
                return entity;
            });
        }

        public virtual TEntity SaveOrUpdate(TEntity entity)
        {
            return ExecuteCommand(MethodBase.GetCurrentMethod(), delegate (ISession session)
            {
                session.SaveOrUpdate(entity);
                return entity;
            });
        }

        protected TResult ExecuteCommand<TResult>(MethodBase method, Func<ISession, TResult> command)
        {
            TResult result = default(TResult);

            using (var session = Session)
            {
                using (var tx = session.BeginTransaction())
                {
                    try
                    {
                        tx.Begin();

                        result = command(session);

                        tx.Commit();

                    }
#pragma warning disable CS0168 // A variável "ex" está declarada, mas nunca é usada
                    catch (Exception ex)
#pragma warning restore CS0168 // A variável "ex" está declarada, mas nunca é usada
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }

            return result;
        }
    }

}
