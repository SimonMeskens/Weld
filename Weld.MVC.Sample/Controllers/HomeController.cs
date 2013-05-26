using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Weld.Attributes;
using Weld.MVC.Sample.Models;
using Weld.Infra;

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

        [AjaxMethod]
        public JsonResult<Person> GetPerson()
        {
            var p = new Person {FirstName = "Jan", LastName = "De Vries"};

            var jsonResult = new JsonResult<Person>(Json(p));
            //jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return jsonResult;
        }
    }
}
