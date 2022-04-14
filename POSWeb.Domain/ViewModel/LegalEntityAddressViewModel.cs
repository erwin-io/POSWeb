using System;
using System.Collections.Generic;

namespace POSWeb.Domain.ViewModel
{
    public class LegalEntityAddressViewModel
    {
        public string LegalEntityAddressId { get; set; }
        public LegalEntityViewModel LegalEntity { get; set; }
        public string Address { get; set; }
        public EntityStatusViewModel EntityStatus { get; set; }
    }
}
