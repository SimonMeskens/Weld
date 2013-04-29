using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Weld.Attributes;

namespace Weld.Infra
{
    public class SimpleEngine : ITemplateEngine
    {
        public string GetClientMethodCode(MethodInfo method,string url)
        {
            var inputParameters =
                method.GetParameters().Select(p => string.Format("{0}: {1}", p.Name, TypeMapper.GetTypeScriptType(p.ParameterType)))
                    .ToList();

            var returnType = method.ReturnType;
            if (returnType.Name != "Void")
            {
                var callbackParameter = "callback: (data: " + TypeMapper.GetTypeScriptType(returnType) + ") => any";
                inputParameters.Add(callbackParameter);
            }

            var allParameters = string.Join(", ", inputParameters);

            var result = "    ";
            result += method.Name + "(" + allParameters + ")\r\n";
            result += "    {\r\n";
            result += "        var url = \"" + url + "\";\r\n";

            var inputJsonTuples = method.GetParameters().Select(p => string.Format("{0}: {0}", p.Name));
            result += "        var data = { " + string.Join(", ", inputJsonTuples) + " };\r\n\r\n";

            var isPost = method.GetCustomAttributes(typeof(HttpPostAttribute), true).Any();
            var ajaxMethod = isPost ? "post" : "get";

            if (returnType.Name == "Void")
            {
                result += "        $." + ajaxMethod + "(url, data);\r\n";

            }
            else
            {
                result += "        $." + ajaxMethod + "(url, data, function (data) {\r\n";
                result += "            callback(data);\r\n";
                result += "        });\r\n";
            }
            result += "    }\r\n";

            return result;
        }
    }
}