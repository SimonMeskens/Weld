using System.Web.Mvc;
using Weld.Attributes;

namespace Weld.Test.Scenarios
{
    class PartialViewController : Controller
    {
        [AjaxMethod]
        public PartialViewResult Store(int x)
        {
            return new PartialViewResult();
        }
    }
}