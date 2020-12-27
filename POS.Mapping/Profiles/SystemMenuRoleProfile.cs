using AutoMapper;
using POSWeb.POSAdmin.Data.Entity;
using POSWeb.POSAdmin.Domain.BindingModel;
using POSWeb.POSAdmin.Domain.ViewModel;
using System.Collections.Generic;

namespace POSWeb.POS.Mapping.Profiles
{
    public class SystemMenuRoleProfile : Profile
    {
        public SystemMenuRoleProfile()
        {
            this.IgnoreUnmapped();
            CreateMap<SystemMenuRoleModel, SystemMenuRoleViewModel>();
            CreateMap<SystemMenuRoleBindingModel, SystemMenuRoleModel>()
                .ForMember(dest => dest.SystemRole, opt => opt.MapFrom(src =>
                new SystemRoleModel
                {
                    SystemRoleId = src.SystemRoleId
                }))
                .ForMember(dest => dest.SystemMenu, opt => opt.MapFrom(src =>
                new SystemMenuModel
                {
                    SystemMenuId = src.SystemMenuId
                }))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src =>
                new SystemUserModel
                {
                    SystemUserId = src.CreatedBy
                }))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => new LocationModel() { LocationId = src.LocationId }));
        }
    }
}
