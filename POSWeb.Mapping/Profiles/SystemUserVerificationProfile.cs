using AutoMapper;
using POSWeb.Data.Entity;
using POSWeb.Domain.BindingModel;
using POSWeb.Domain.ViewModel;
using System.Collections.Generic;

namespace POSWeb.Mapping.Profiles
{
    public class SystemUserVerificationProfile : Profile
    {
        public SystemUserVerificationProfile()
        {
            this.IgnoreUnmapped();
            CreateMap<SystemUserVerificationModel, SystemUserVerificationViewModel>();
            CreateMap<SystemUserVerificationBindingModel, SystemUserVerificationModel>();
        }
    }
}
