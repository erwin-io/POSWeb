using POSWeb.Data.Core;
using POSWeb.Data.Entity;
using System.Collections.Generic;

namespace POSWeb.Data.Interface
{
    public interface ILegalEntityAddressRepositoryDAC : IRepository<LegalEntityAddressModel>
    {
        List<LegalEntityAddressModel> FindBySystemUserId(string SystemUserId);
        List<LegalEntityAddressModel> FindByLegalEntityId(string LegalEntityId);
    }
}