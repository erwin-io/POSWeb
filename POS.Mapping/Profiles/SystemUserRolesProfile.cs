using AutoMapper;
using POSWeb.POSAdmin.Data.Entity;
using POSWeb.POSAdmin.Domain.BindingModel;
using POSWeb.POSAdmin.Domain.ViewModel;
using System.Collections.Generic;

namespace POSWeb.POS.Mapping.Profiles
{
    public class SystemUserRolesProfile : Profile
    {
        public SystemUserRolesProfile()
        {
            this.IgnoreUnmapped();
            CreateMap<SystemUserRolesModel, SystemUserRolesViewModel>();
            CreateMap<SystemUserRolesBindingModel, SystemUserRolesModel>()
                .ForPath(dest => dest.SystemRole, opt => opt.MapFrom(src =>
                new SystemRoleModel
                {
                    SystemRoleId = src.SystemRoleId
                }))
                .ForPath(dest => dest.SystemUser, opt => opt.MapFrom(src => 
                new SystemUserModel() 
                { 
                    SystemUserId = src.SystemUserId
                }))
                .ForPath(dest => dest.CreatedBy, opt => opt.MapFrom(src =>
                new SystemRecordManagerModel
                {
                    SystemUserId = src.CreatedBy
                }))
                .ForPath(dest => dest.Location, opt => opt.MapFrom(src =>
                new LocationModel()
                {
                    LocationId = src.LocationId
                }));
        }
    }
}
