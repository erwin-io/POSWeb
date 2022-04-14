using POSWeb.Data.Core;
using POSWeb.Data.Entity;
using System.Collections.Generic;

namespace POSWeb.Data.Interface
{
    public interface ISystemConfigRepositoryDAC : IRepository<SystemConfigModel>
    {
        SystemConfigModel Find(long id);
    }
}
