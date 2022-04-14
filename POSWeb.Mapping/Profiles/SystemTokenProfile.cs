using AutoMapper;
using POSWeb.Data.Entity;
using POSWeb.Domain.BindingModel;
using POSWeb.Domain.ViewModel;
using System.Collections.Generic;

namespace POSWeb.Mapping.Profiles
{
    public class SystemTokenProfile : Profile
    {
        public SystemTokenProfile()
        {
            this.IgnoreUnmapped();
            CreateMap<SystemTokenModel, SystemRefreshTokenViewModel>()
                .ForPath(dest => dest.UserId, opt => opt.MapFrom(src => src.SystemUser.SystemUserId));
            CreateMap<SystemRefreshTokenBindingModel, SystemTokenModel>()
                .ForPath(dest => dest.SystemUser, opt => opt.MapFrom(src =>
                    new SystemUserModel
                    {
                        SystemUserId = src.UserId
                    }));
        }
    }
}
