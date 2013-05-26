using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weld.Attributes;

namespace Weld.Test.ViewModels
{
    [WeldViewModel]
    class SimpleViewModel
    {
        public bool Enabled { get; set; }

        public string FirstName { get; set; }
        
    }
}
