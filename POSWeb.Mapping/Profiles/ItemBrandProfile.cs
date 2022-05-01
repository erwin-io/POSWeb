using AutoMapper;
using POSWeb.Data.Entity;
using POSWeb.Domain.BindingModel;
using POSWeb.Domain.ViewModel;
using System.Collections.Generic;

namespace POSWeb.Mapping.Profiles
{
    public class ItemBrandProfile : Profile
    {
        public ItemBrandProfile()
        {
            this.IgnoreUnmapped();
            CreateMap<ItemBrandModel, ItemBrandViewModel>();
            CreateMap<ItemBrandBindingModel, ItemBrandModel>()
                .ForPath(dest => dest.SystemRecordManager, opt => opt.MapFrom(src =>
                    new SystemRecordManagerModel()));
            CreateMap<UpdateItemBrandBindingModel, ItemBrandModel>()
                .ForPath(dest => dest.SystemRecordManager, opt => opt.MapFrom(src =>
                    new SystemRecordManagerModel()));
        }
    }
}
