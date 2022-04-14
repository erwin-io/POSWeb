using System;
using System.Collections.Generic;

namespace POSWeb.Domain.BindingModel
{
    public class UpdateSystemUserConfigBindingModel
    {
        public string SystemUserConfigId { get; set; }
        public bool IsUserEnable { get; set; }
    }
}
