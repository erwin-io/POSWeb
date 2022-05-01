using POSWeb.Domain.BindingModel;
using POSWeb.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSWeb.Facade.Interface
{
    public interface IItemFacade
    {
        string Add(CreateItemBindingModel model, string CreatedBy);
        ItemViewModel Find(string id);
        bool Remove(string id, string LastUpdatedBy);
        bool Update(UpdateItemBindingModel model, string LastUpdatedBy);
        PageResultsViewModel<ItemViewModel> GetPage(string Search, int PageNo, int PageSize, string OrderColumn, string OrderDir);
    }
}
