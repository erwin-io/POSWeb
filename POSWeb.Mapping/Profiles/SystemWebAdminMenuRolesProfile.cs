using AutoMapper;
using POSWeb.Data.Entity;
using POSWeb.Domain.BindingModel;
using POSWeb.Domain.ViewModel;
using System.Collections.Generic;

namespace POSWeb.Mapping.Profiles
{
    public class SystemWebAdminMenuRolesProfile : Profile
    {
        public SystemWebAdminMenuRolesProfile()
        {
            this.IgnoreUnmapped();
            CreateMap<SystemWebAdminMenuRolesModel, SystemWebAdminMenuRolesViewModel>();
        }
    }
}
