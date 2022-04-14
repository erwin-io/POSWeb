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
    public class LookupFacade : ILookupFacade
    {
        private readonly ILookupTableRepositoryDAC _lookupTableRepositoryDAC;

        #region CONSTRUCTORS
        public LookupFacade(ILookupTableRepositoryDAC lookupTableRepositoryDAC)
        {
            _lookupTableRepositoryDAC = lookupTableRepositoryDAC ?? throw new ArgumentNullException(nameof(lookupTableRepositoryDAC));
        }
        #endregion

        public List<LookupTableViewModel> FindLookupByTableNames(string TableNames) => AutoMapperHelper<LookupTableModel, LookupTableViewModel>.MapList(_lookupTableRepositoryDAC.FindLookupByTableNames(TableNames)).ToList();
        public List<LookupTableViewModel> FindEnforcementUnitByEnforcementStationId(string EnforcementStationId) => AutoMapperHelper<LookupTableModel, LookupTableViewModel>.MapList(_lookupTableRepositoryDAC.FindEnforcementUnitByEnforcementStationId(EnforcementStationId)).ToList();
    }
}
