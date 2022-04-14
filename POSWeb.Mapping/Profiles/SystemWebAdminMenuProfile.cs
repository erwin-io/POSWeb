using AutoMapper;
using POSWeb.Data.Entity;
using POSWeb.Domain.BindingModel;
using POSWeb.Domain.ViewModel;
using System.Collections.Generic;

namespace POSWeb.Mapping.Profiles
{
    public class SystemWebAdminMenuProfile : Profile
    {
        public SystemWebAdminMenuProfile()
        {
            this.IgnoreUnmapped();
            CreateMap<SystemWebAdminMenuModel, SystemWebAdminMenuViewModel>();
            CreateMap<SystemWebAdminModuleModel, SystemWebAdminModuleViewModel>();
        }
    }
}
