using System.Web.Mvc;
using Weld.Attributes;

namespace Weld.Test.Scenarios
{
    public class BoolMethod
    {
        [AjaxMethod]
        public void Store(bool value)
        {
            
        }
    }
}