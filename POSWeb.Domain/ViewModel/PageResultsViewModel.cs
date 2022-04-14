using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSWeb.Domain.ViewModel
{
    public class PageResultsViewModel<T>
    {
        public IEnumerable<T> Items { get; set; }
        public long TotalRows { get; set; }
    }
}
