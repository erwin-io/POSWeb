using AutoMapper;
using POSWeb.Data.Entity;
using POSWeb.Domain.BindingModel;
using POSWeb.Domain.ViewModel;
using System.Collections.Generic;

namespace POSWeb.Mapping.Profiles
{
    public class LookupTableProfile : Profile
    {
        public LookupTableProfile()
        {
            this.IgnoreUnmapped();
            CreateMap<LookupModel, LookupViewModel>();
            CreateMap<LookupTableModel, LookupTableViewModel>();
        }
    }
}
