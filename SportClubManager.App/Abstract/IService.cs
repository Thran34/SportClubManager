using SportClubManager.Domain.Common;

namespace SportClubManager.App.Abstract
{
    public interface IService<T> where T : BaseEntity
    {
        List<T> Items { get; set; }
        int AddItem(T item);
        int UpdateItem(T item);
        void RemoveItem(T item);
        List<T> GetAllItems();
        T GetItemById(int id);
        int GetLastId();
    }
}
