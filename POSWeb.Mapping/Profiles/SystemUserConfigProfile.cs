using AutoMapper;
using POSWeb.Data.Entity;
using POSWeb.Domain.BindingModel;
using POSWeb.Domain.ViewModel;
using System.Collections.Generic;

namespace POSWeb.Mapping.Profiles
{
    public class SystemUserConfigProfile : Profile
    {
        public SystemUserConfigProfile()
        {
            this.IgnoreUnmapped();
            CreateMap<SystemUserConfigModel, SystemUserConfigViewModel>();
            CreateMap<UpdateSystemUserConfigBindingModel, SystemUserConfigModel>();
        }
    }
}
