using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSWeb.POSAdmin.Domain.BindingModel
{
    public class SystemUserRolesBindingModel
    {
        public string SystemUserId { get; set; }
        public string SystemRoleId { get; set; }
        public long LocationId { get; set; }
        public string CreatedBy { get; set; }
    }
}
