﻿using POSWeb.Domain.BindingModel;
using POSWeb.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSWeb.Facade.Interface
{
    public interface ISystemWebAdminRolePrivilegesFacade
    {
        bool Set(SystemWebAdminRolePrivilegesBindingModel model, string CreatedBy);
        List<SystemWebAdminRolePrivilegesViewModel> FindBySystemWebAdminRoleId(string SystemWebAdminRoleId);
    }
}