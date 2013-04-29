using Weld.Attributes;

namespace Weld.Test.Scenarios
{
    class MethodWithReturnValue
    {
        [AjaxMethod]
        public int Sum(int x, int y)
        {
            return x + y;
        }
    }
}