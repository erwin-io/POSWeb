using AutoMapper;
using POSWeb.POSAdmin.Data.Entity;
using POSWeb.POSAdmin.Domain.BindingModel;
using POSWeb.POSAdmin.Domain.ViewModel;
using System.Collections.Generic;

namespace POSWeb.POS.Mapping.Profiles
{
    public class SystemRoleProfile : Profile
    {
        public SystemRoleProfile()
        {
            this.IgnoreUnmapped();
            CreateMap<SystemRoleModel, SystemRoleViewModel>();
            CreateMap<SystemRoleBindingModel, SystemRoleModel>()
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src =>
                new SystemUserModel
                {
                    SystemUserId = src.CreatedBy
                }))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => new LocationModel() { LocationId = src.LocationId }));
            CreateMap<UpdateSystemRoleBindingModel, SystemRoleModel>()
                .ForMember(dest => dest.UpdatedBy, opt => opt.MapFrom(src =>
                new SystemUserModel
                {
                    SystemUserId = src.UpdatedBy
                }));
        }
    }
}
