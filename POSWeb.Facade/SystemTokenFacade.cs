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
    public class SystemTokenFacade : ISystemTokenFacade
    {
        private readonly ISystemTokenRepositoryDAC _systemTokenRepositoryDAC;

        #region CONSTRUCTORS
        public SystemTokenFacade(ISystemTokenRepositoryDAC systemTokenRepositoryDAC)
        {
            _systemTokenRepositoryDAC = systemTokenRepositoryDAC ?? throw new ArgumentNullException(nameof(systemTokenRepositoryDAC));
        }
        #endregion

        public string Add(SystemRefreshTokenBindingModel model)
        {
            try
            {
                var id = _systemTokenRepositoryDAC.Add(AutoMapperHelper<SystemRefreshTokenBindingModel, SystemTokenModel>.Map(model));
                return id;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public SystemRefreshTokenViewModel Find(string hashedTokenId) => AutoMapperHelper<SystemTokenModel, SystemRefreshTokenViewModel>.Map(_systemTokenRepositoryDAC.Find(hashedTokenId));
    }
}
