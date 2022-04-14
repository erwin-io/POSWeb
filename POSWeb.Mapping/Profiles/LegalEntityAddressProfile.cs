using AutoMapper;
using POSWeb.Data.Entity;
using POSWeb.Domain.BindingModel;
using POSWeb.Domain.ViewModel;
using System.Collections.Generic;

namespace POSWeb.Mapping.Profiles
{
    public class LegalEntityAddressProfile : Profile
    {
        public LegalEntityAddressProfile()
        {
            this.IgnoreUnmapped();
            CreateMap<LegalEntityAddressModel, LegalEntityAddressViewModel>();
            CreateMap<LegalEntityAddressBindingModel, LegalEntityAddressModel>();
            CreateMap<CreateLegalEntityAddressBindingModel, LegalEntityAddressModel>()
                .ForPath(dest => dest.LegalEntity, opt => opt.MapFrom(src =>
                    new LegalEntityModel
                    {
                        LegalEntityId = src.LegalEntityId
                    }));
            CreateMap<UpdateLegalEntityAddressBindingModel, LegalEntityAddressModel>();
        }
    }
}
