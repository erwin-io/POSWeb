using AutoMapper;
using POSWeb.Data.Entity;
using POSWeb.Domain.BindingModel;
using POSWeb.Domain.ViewModel;
using System.Collections.Generic;

namespace POSWeb.Mapping.Profiles
{
    public class SystemWebAdminRoleProfile : Profile
    {
        public SystemWebAdminRoleProfile()
        {
            this.IgnoreUnmapped();
            CreateMap<SystemWebAdminRoleModel, SystemWebAdminRoleViewModel>();
            CreateMap<SystemWebAdminRoleBindingModel, SystemWebAdminRoleModel>()
                .ForPath(dest => dest.SystemRecordManager, opt => opt.MapFrom(src =>
                    new SystemRecordManagerModel()));
            CreateMap<UpdateSystemWebAdminRoleBindingModel, SystemWebAdminRoleModel>()
                .ForPath(dest => dest.SystemRecordManager, opt => opt.MapFrom(src =>
                    new SystemRecordManagerModel()));
        }
    }
}
