using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Weld.Attributes;

namespace Weld.MVC.Sample.Controllers
{
    public class AnotherController : Controller
    {
        [AjaxMethod]
        public int TakeFive()
        {
            return 5;
        }

    }
}
