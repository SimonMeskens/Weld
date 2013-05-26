using System.Web.Mvc;
using Weld.Attributes;

namespace Weld.Test.Scenarios
{
    class ClientUrlController : Controller
    {
        [ClientUrl]
        public void Store(int x)
        {

        }

        [ClientUrl(Url = "/Some/Custom/Url")]
        public void Get(int x)
        {

        }
    }
}