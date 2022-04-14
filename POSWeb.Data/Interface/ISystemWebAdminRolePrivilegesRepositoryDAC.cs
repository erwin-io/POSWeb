using POSWeb.Data.Core;
using POSWeb.Data.Entity;
using System.Collections.Generic;

namespace POSWeb.Data.Interface
{
    public interface ISystemWebAdminRolePrivilegesRepositoryDAC : IRepository<SystemWebAdminRolePrivilegesModel>
    {
        SystemWebAdminRolePrivilegesModel FindBySystemWebAdminPrivilegeIdAndSystemWebAdminRoleId(long SystemWebAdminPrivilegeId, string SystemWebAdminRoleId);
        List<SystemWebAdminRolePrivilegesModel> FindBySystemWebAdminRoleId(string SystemWebAdminRoleId);
        bool Remove(string id, string LastUpdatedBy);
    }
}
