using AutoMapper;
using POSWeb.Data.Entity;
using POSWeb.Domain.BindingModel;
using POSWeb.Domain.ViewModel;
using System.Collections.Generic;

namespace POSWeb.Mapping.Profiles
{
    public class SystemWebAdminUserRolesProfile : Profile
    {
        public SystemWebAdminUserRolesProfile()
        {
            this.IgnoreUnmapped();
            CreateMap<SystemWebAdminUserRolesModel, SystemWebAdminUserRolesViewModel>();
            CreateMap<SystemWebAdminUserRolesBindingModel, SystemWebAdminUserRolesViewModel>()
                .ForPath(dest => dest.SystemWebAdminRole, opt => opt.MapFrom(src =>
                    new SystemWebAdminRoleModel() { SystemWebAdminRoleId = src.SystemWebAdminRoleId }))
                .ForPath(dest => dest.SystemRecordManager, opt => opt.MapFrom(src =>
                    new SystemRecordManagerModel()));
        }
    }
}
