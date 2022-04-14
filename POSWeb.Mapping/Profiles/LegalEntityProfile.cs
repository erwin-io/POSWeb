using AutoMapper;
using POSWeb.Data.Entity;
using POSWeb.Domain.BindingModel;
using POSWeb.Domain.ViewModel;
using System.Collections.Generic;

namespace POSWeb.Mapping.Profiles
{
    public class LegalEntityProfile : Profile
    {
        public LegalEntityProfile()
        {
            this.IgnoreUnmapped();
            CreateMap<LegalEntityModel, LegalEntityViewModel>();
            CreateMap<EntityGenderModel, EntityGenderViewModel>();
            CreateMap<EntityStatusModel, EntityStatusViewModel>();
        }
    }
}
