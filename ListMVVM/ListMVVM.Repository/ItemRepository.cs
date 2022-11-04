using ListMVVM.Model;
using ListMVVM.Repository.Default;
using NHibernate;
using System.Collections.Generic;

namespace ListMVVM.Repository
{
    public class ItemRepository : AbstractRepository<Item>
    {
        private ISession CreateSession() => NHibernateHelper.GetCurrentSession();

        //Calling queries from Item.hbm.xml:
        //Using QueryOver (NHIBERNATE) -> don't need implementation in Item.hbm.xml (easier method for simple filters):
        public IList<Item> FindByItemName(string itemName)
        {
            ISession session = CreateSession();

            IList<Item> resultList = session.QueryOver<Item>().Where(x => x.ItemName == itemName).List();

            return resultList;
        }
    }
}
