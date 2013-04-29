using System.Web.Mvc;
using Weld.Attributes;

namespace Weld.Test.Scenarios
{
    public class PostStringMethod
    {
        [HttpPost]
        [AjaxMethod]
        public string Echo(string value)
        {
            return "hoi";
        }
    }
}