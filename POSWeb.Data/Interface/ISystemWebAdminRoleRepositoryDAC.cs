﻿using POSWeb.Data.Core;
using POSWeb.Data.Entity;
using System.Collections.Generic;

namespace POSWeb.Data.Interface
{
    public interface ISystemWebAdminRoleRepositoryDAC : IRepository<SystemWebAdminRoleModel>
    {
        List<SystemWebAdminRoleModel> GetPage(string Search, int PageNo, int PageSize, string OrderColumn, string OrderDir);
        bool Remove(string id, string LastUpdatedBy);
    }
}