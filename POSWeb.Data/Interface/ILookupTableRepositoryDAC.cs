using POSWeb.Data.Core;
using POSWeb.Data.Entity;
using System.Collections.Generic;

namespace POSWeb.Data.Interface
{
    public interface ILookupTableRepositoryDAC : IRepository<LookupTableModel>
    {
        List<LookupTableModel> FindLookupByTableNames(string TableNames);
        List<LookupTableModel> FindEnforcementUnitByEnforcementStationId(string EnforcementStationId);
    }
}
