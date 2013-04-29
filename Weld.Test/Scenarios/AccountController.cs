using System.Web.Mvc;
using Weld.Attributes;

namespace Weld.Test.Scenarios
{
    class AccountController : Controller
    {
        [AjaxMethod]
        public void Store(int x)
        {

        }
    }
}