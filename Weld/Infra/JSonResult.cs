using System.Web.Mvc;

namespace Weld.Infra
{
    public class JsonResult<T>:JsonResult
    {
        public JsonResult(JsonResult result)
        {
            ContentEncoding = result.ContentEncoding;
            ContentType = result.ContentType;
            Data = result.Data;
            JsonRequestBehavior = result.JsonRequestBehavior;
        }
    }
}