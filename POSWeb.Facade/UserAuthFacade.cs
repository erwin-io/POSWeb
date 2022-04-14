using POSWeb.Mapping;
using POSWeb.Data.Entity;
using POSWeb.Data.Interface;
using POSWeb.Domain.BindingModel;
using POSWeb.Domain.ViewModel;
using POSWeb.Facade.Interface;
using System;
using System.Collections.Generic;
using System.Transactions;

namespace POSWeb.Facade
{
    public class UserAuthFacade : IUserAuthFacade
    {
        private readonly ISystemUserRepositoryDAC _systemUserRepository;

        #region CONSTRUCTORS
        public UserAuthFacade(ISystemUserRepositoryDAC systemUserRepository)
        {
            _systemUserRepository = systemUserRepository ?? throw new ArgumentNullException(nameof(systemUserRepository));
        }
        #endregion
        public SystemUserViewModel Find(string id) => AutoMapperHelper<SystemUserModel, SystemUserViewModel>.Map(_systemUserRepository.Find(id));

        public SystemUserViewModel Find(string Username, string Password) => AutoMapperHelper<SystemUserModel, SystemUserViewModel>.Map(_systemUserRepository.Find(Username, Password));
    }
}
