using POSWeb.Domain.BindingModel;
using POSWeb.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSWeb.Facade.Interface
{
    public interface IItemBrandFacade
    {
        string Add(CreateItemBrandBindingModel model, string CreatedBy);
        ItemBrandViewModel Find(string id);
        bool Remove(string id, string LastUpdatedBy);
        bool Update(UpdateItemBrandBindingModel model, string LastUpdatedBy);
        PageResultsViewModel<ItemBrandViewModel> GetPage(string Search, int PageNo, int PageSize, string OrderColumn, string OrderDir);
    }
}
