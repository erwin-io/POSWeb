﻿using POSWeb.Domain.BindingModel;
using POSWeb.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSWeb.Facade.Interface
{
    public interface ISystemWebAdminMenuRolesFacade
    {
        bool Set(SystemWebAdminMenuRolesBindingModel model, string CreatedBy);
        List<SystemWebAdminMenuRolesViewModel> FindBySystemWebAdminRoleIdandSystemWebAdminModuleId(string SystemWebAdminRoleId, long SystemWebAdminModuleId);
        List<SystemWebAdminMenuRolesViewModel> FindBySystemWebAdminRoleId(string SystemWebAdminRoleId);
    }
}