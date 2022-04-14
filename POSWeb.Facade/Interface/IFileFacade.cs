using POSWeb.Domain.BindingModel;
using POSWeb.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSWeb.Facade.Interface
{
    public interface IFileFacade
    {
        FileViewModel Find(string id);
    }
}
