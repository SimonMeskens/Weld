using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Weld.Attributes;

namespace Weld.MVC.Sample.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        
        [HttpGet]
        [AjaxMethod]
        public int Sum(int x,int y)
        {
            return x + y;
        }



        [HttpGet]
        [AjaxMethod]
        public void Store(int x)
        {
            Debug.WriteLine("Store hit with {0}", x);
        }
    }
}
