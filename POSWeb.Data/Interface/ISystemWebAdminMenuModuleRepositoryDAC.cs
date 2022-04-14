using POSWeb.Data.Core;
using POSWeb.Data.Entity;
using System.Collections.Generic;

namespace POSWeb.Data.Interface
{
    public interface ISystemWebAdminMenuModuleRepositoryDAC : IRepository<SystemWebAdminModuleModel>
    {
        SystemWebAdminModuleModel FindByMenuId(long menuId);
    }
}
