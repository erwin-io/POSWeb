using AutoMapper;
using POSWeb.Data.Entity;
using POSWeb.Domain.BindingModel;
using POSWeb.Domain.ViewModel;
using System.Collections.Generic;

namespace POSWeb.Mapping.Profiles
{
    public class FIleProfile : Profile
    {
        public FIleProfile()
        {
            this.IgnoreUnmapped();
            CreateMap<FileModel, FileViewModel>();
            CreateMap<FileBindingModel, FileModel>()
                .ForPath(dest => dest.SystemRecordManager, opt => opt.MapFrom(src =>
                    new SystemRecordManagerModel()));
            CreateMap<UpdateFileBindingModel, FileModel>()
                .ForPath(dest => dest.SystemRecordManager, opt => opt.MapFrom(src =>
                    new SystemRecordManagerModel()));
        }
    }
}
