using System;
using System.Collections.Generic;

namespace POSWeb.POSAdmin.Data.Entity
{
    public class SystemRoleModel
    {
        public string SystemRoleId { get; set; }
        public string Name { get; set; }
        public LocationModel Location { get; set; }
        public SystemUserModel CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public SystemUserModel UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
