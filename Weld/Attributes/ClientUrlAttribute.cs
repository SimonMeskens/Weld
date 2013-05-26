using System;
using System.Reflection;
using Weld.Infra;

namespace Weld.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ClientUrlAttribute : WeldAttribute
    {
        public override string GetCode(MemberInfo method)
        {
            var methodInfo = (MethodInfo)method;
            //very naive url determining does not take custom action names and routing into account (yet)
            var fieldName = "Url" + methodInfo.Name;
            var controllerName = methodInfo.DeclaringType.Name;
            if (controllerName.EndsWith("Controller"))
            {
                controllerName = controllerName.Substring(0, controllerName.LastIndexOf("Controller"));
            }
            var actionName = methodInfo.Name;

            var url = string.IsNullOrEmpty(Url) ? 
                string.Format("/{0}/{1}/", controllerName, actionName) : Url;
            
            return string.Format("    public static {0}: string = \"{1}\";\r\n", fieldName, url);
        }

        public string Url { get; set; }
    }
}