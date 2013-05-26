using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weld.Attributes;
using Weld.Infra;
using Weld.Test.Models;

namespace Weld.Test.Scenarios
{
    class JSonResultSample
    {
        [AjaxMethod]
        public JsonResult<Person> GetPerson(int id)
        {
            return null;
        }
    }
}
