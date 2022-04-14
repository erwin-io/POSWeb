using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSWeb.Domain.ViewModel
{
    public class LookupTableViewModel
    {
        public string LookupName { get; set; }
        public List<LookupViewModel> LookupData { get; set; }
    }
}
