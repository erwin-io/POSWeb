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
    public class SystemConfigFacade : ISystemConfigFacade
    {
        private readonly ISystemConfigRepositoryDAC _systemConfigRepositoryDAC;

        #region CONSTRUCTORS
        public SystemConfigFacade(ISystemConfigRepositoryDAC systemConfigRepositoryDAC)
        {
            _systemConfigRepositoryDAC = systemConfigRepositoryDAC ?? throw new ArgumentNullException(nameof(systemConfigRepositoryDAC));
        }
        #endregion

        public SystemConfigViewModel Find(long id) => AutoMapperHelper<SystemConfigModel, SystemConfigViewModel>.Map(_systemConfigRepositoryDAC.Find(id));

        public List<SystemConfigViewModel> GetAll() => AutoMapperHelper<SystemConfigModel, SystemConfigViewModel>.MapList(_systemConfigRepositoryDAC.GetAll()).ToList();

        public bool Update(UpdateSystemConfigBindingModel model)
        {
            bool success = false;
            try
            {
                success = _systemConfigRepositoryDAC.Update(AutoMapperHelper<UpdateSystemConfigBindingModel, SystemConfigModel>.Map(model));
                return success;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
