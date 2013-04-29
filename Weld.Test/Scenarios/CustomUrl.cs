using Weld.Attributes;

namespace Weld.Test.Scenarios
{
    public class CustomUrl
    {
        [AjaxMethod(Url="Custom")]
        public void Method(string value)
        {
            
        }
    }
}