using System.Web.Mvc;
using Weld.Attributes;

namespace Weld.Test.Scenarios
{
    class ContentResultSample: Controller
    {
        [AjaxMethod]
        public ContentResult Store(int x)
        {
            return new ContentResult();
        }
    }
}