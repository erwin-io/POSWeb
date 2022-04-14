using POSWeb.Mapping;
using POSWeb.Data.Entity;
using POSWeb.Data.Interface;
using POSWeb.Domain.BindingModel;
using POSWeb.Domain.ViewModel;
using POSWeb.Facade.Interface;
using System;
using System.Collections.Generic;
using System.Transactions;
using System.Linq;

namespace POSWeb.Facade
{
    public class FileFacade : IFileFacade
    {
        private readonly IFileRepositoryRepositoryDAC _fileRepositoryRepositoryDAC;

        #region CONSTRUCTORS
        public FileFacade(IFileRepositoryRepositoryDAC fileRepositoryRepositoryDAC)
        {
            _fileRepositoryRepositoryDAC = fileRepositoryRepositoryDAC ?? throw new ArgumentNullException(nameof(fileRepositoryRepositoryDAC));
        }
        #endregion

        public FileViewModel Find(string id) => AutoMapperHelper<FileModel, FileViewModel>.Map(_fileRepositoryRepositoryDAC.Find(id));
    }
}
