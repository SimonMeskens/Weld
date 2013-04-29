using Weld.Attributes;

namespace Weld.Test.Scenarios
{
    public class StringMethod
    {
        [AjaxMethod]
        public string Echo(string value)
        {
            return "hoi";
        }
    }
}