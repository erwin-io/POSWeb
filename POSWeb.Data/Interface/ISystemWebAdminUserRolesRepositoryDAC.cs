﻿using POSWeb.Data.Core;
using POSWeb.Data.Entity;
using System.Collections.Generic;

namespace POSWeb.Data.Interface
{
    public interface ISystemWebAdminUserRolesRepositoryDAC : IRepository<SystemWebAdminUserRolesModel>
    {
        List<SystemWebAdminUserRolesModel> GetPage(string Search, string SystemUserId, int PageNo, int PageSize, string OrderColumn, string OrderDir);
        SystemWebAdminUserRolesModel FindBySystemWebAdminRoleIdAndSystemUserId(string SystemWebAdminRoleId, string SystemUserId);
        List<SystemWebAdminUserRolesModel> FindBySystemUserId(string SystemUserId);
        bool Remove(string id, string LastUpdatedBy);
    }
}