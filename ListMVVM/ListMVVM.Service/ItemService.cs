using ListMVVM.Model;
using ListMVVM.Repository;

namespace ListMVVM.Service
{
    public class ItemService : AbstractService<Item>
    {
        private static ItemRepository _itemRepository = new ItemRepository();

        public ItemService() : base(_itemRepository) { }
    }
}
