
using System;

namespace POSWeb.Data.Entity
{
    public class SystemWebAdminMenuModel
    {
        public long? SystemWebAdminMenuId { get; set; }
        public SystemWebAdminModuleModel SystemWebAdminModule { get; set; }
        public string SystemWebAdminMenuName { get; set; }
    }
}
