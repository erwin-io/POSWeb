using AutoMapper;
using POSWeb.Data.Entity;
using POSWeb.Domain.BindingModel;
using POSWeb.Domain.ViewModel;
using System.Collections.Generic;

namespace POSWeb.Mapping.Profiles
{
    public class SystemWebAdminRolePrivilegesProfile : Profile
    {
        public SystemWebAdminRolePrivilegesProfile()
        {
            this.IgnoreUnmapped();
            CreateMap<SystemWebAdminRolePrivilegesModel, SystemWebAdminRolePrivilegesViewModel>();
        }
    }
}
