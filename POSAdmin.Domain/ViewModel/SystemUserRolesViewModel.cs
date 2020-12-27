using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace POSWeb.POSAdmin.Domain.ViewModel
{
    public class SystemUserRolesViewModel
    {
        public string SystemUserRoleId { get; set; }
        public SystemRoleViewModel SystemRole { get; set; }
        public SystemUserViewModel SystemUser { get; set; }
        public LocationViewModel Location { get; set; }
    }
}
