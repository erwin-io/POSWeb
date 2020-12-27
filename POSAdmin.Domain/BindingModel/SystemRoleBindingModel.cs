using System.Collections.Generic;

namespace POSWeb.POSAdmin.Domain.BindingModel
{
    public class SystemRoleBindingModel
    {
        public string Name { get; set; }
        public long LocationId { get; set; }
        public string CreatedBy { get; set; }
    }
    public class UpdateSystemRoleBindingModel
    {
        public string SystemRoleId { get; set; }
        public string Name { get; set; }
        public string UpdatedBy { get; set; }
    }
}
