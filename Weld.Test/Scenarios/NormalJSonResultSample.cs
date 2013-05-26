using System.Web.Mvc;
using Weld.Attributes;

namespace Weld.Test.Scenarios
{
    class NormalJSonResultSample
    {
        [AjaxMethod]
        public JsonResult GetPerson(int id)
        {
            return null;
        }
    }
}