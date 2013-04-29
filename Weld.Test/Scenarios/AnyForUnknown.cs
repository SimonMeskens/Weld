using Weld.Attributes;

namespace Weld.Test.Scenarios
{
    public class AnyForUnknown
    {
        [AjaxMethod]
        public void StoreUnknownType(AjaxMethodAttribute value)
        {

        }
    }
}