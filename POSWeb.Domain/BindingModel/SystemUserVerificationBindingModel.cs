using System;
using System.Collections.Generic;

namespace POSWeb.Domain.BindingModel
{
    public class SystemUserVerificationBindingModel
    {
        public string VerificationSender { get; set; }
        public string VerificationTypeId { get; set; }
    }
}
