using POSWeb.Data.Core;
using POSWeb.Data.Entity;
using System.Collections.Generic;

namespace POSWeb.Data.Interface
{
    public interface ISystemUserVerificationRepositoryDAC : IRepository<SystemUserVerificationModel>
    {
        SystemUserVerificationModel FindBySender(string sender, string code);
        bool VerifyUser(long id);
    }
}
