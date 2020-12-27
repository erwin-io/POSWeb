using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSWeb.POSAdmin.Data.Entity
{
    public class SystemRolePrivilegesModel
    {
        public string SystemRolePrivilegesId { get; set; }
        public SystemRoleModel SystemRole { get; set; }
        public SystemPrivilegeModel SystemPrivilege { get; set; }
        public bool IsAllowed { get; set; }
        public LocationModel Location { get; set; }
        public SystemUserModel CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public SystemUserModel UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
