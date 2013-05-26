using System.Web.Mvc;
using Weld.Attributes;

namespace Weld.Test.Scenarios
{
    class AccountController : Controller
    {
        //make the url available client side..assume default routing
        [AjaxMethod]
        public void Store(int x)
        {

        }
    }
}