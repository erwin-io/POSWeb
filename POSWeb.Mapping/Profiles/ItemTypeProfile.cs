using AutoMapper;
using POSWeb.Data.Entity;
using POSWeb.Domain.BindingModel;
using POSWeb.Domain.ViewModel;
using System.Collections.Generic;

namespace POSWeb.Mapping.Profiles
{
    public class ItemTypeProfile : Profile
    {
        public ItemTypeProfile()
        {
            this.IgnoreUnmapped();
            CreateMap<ItemTypeModel, ItemTypeViewModel>();
            CreateMap<ItemTypeBindingModel, ItemTypeModel>()
                .ForPath(dest => dest.SystemRecordManager, opt => opt.MapFrom(src =>
                    new SystemRecordManagerModel()));
            CreateMap<UpdateItemTypeBindingModel, ItemTypeModel>()
                .ForPath(dest => dest.SystemRecordManager, opt => opt.MapFrom(src =>
                    new SystemRecordManagerModel()));
        }
    }
}
