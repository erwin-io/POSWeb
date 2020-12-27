
namespace POSWeb.POSAdmin.Data.Entity
{
    public class SystemMenuModel
    {
        public string MenuId { get; set; }
        public string ModuleName { get; set; }
        public string PageName { get; set; }
    }

    public class SystemMenuRoleModel : SystemMenuModel
    {
        public string MenuRoleId { get; set; }
        public string RoleId { get; set; }
        public string LocationId { get; set; }
        public bool IsAllowed { get; set; }
    }
}
