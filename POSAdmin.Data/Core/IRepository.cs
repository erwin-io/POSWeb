using System.Collections.Generic;

namespace POSWeb.POSAdmin.Data.Core
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T Find(string id);
        string Add(T item);
        bool Remove(string id);
        bool Update(T item);

    }
}
