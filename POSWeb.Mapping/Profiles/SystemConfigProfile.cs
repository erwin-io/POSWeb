using AutoMapper;
using POSWeb.Data.Entity;
using POSWeb.Domain.BindingModel;
using POSWeb.Domain.ViewModel;
using System.Collections.Generic;

namespace POSWeb.Mapping.Profiles
{
    public class SystemConfigProfile : Profile
    {
        public SystemConfigProfile()
        {
            this.IgnoreUnmapped();
            CreateMap<SystemConfigModel, SystemConfigViewModel>();
            CreateMap<SystemConfigBindingModel, SystemConfigModel>()
                .ForPath(dest => dest.SystemConfigType, opt => opt.MapFrom(src =>
                    new SystemConfigTypeModel() { SystemConfigTypeId = src.SystemConfigTypeId }));
            CreateMap<UpdateSystemConfigBindingModel, SystemConfigModel>()
                .ForPath(dest => dest.SystemConfigType, opt => opt.MapFrom(src =>
                    new SystemConfigTypeModel() { SystemConfigTypeId = src.SystemConfigTypeId }));
        }
    }
}
