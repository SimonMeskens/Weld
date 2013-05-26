using Weld.Attributes;

namespace Weld.Test.ViewModels
{
    [WeldViewModel]
    class NestedViewModel
    {
        public bool Enabled { get; set; }

        public string FirstName { get; set; }

        public SimpleViewModel Nested { get; set; }
        
    }
}