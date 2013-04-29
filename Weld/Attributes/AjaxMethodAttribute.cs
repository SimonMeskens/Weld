using System;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Mvc;
using Weld.Infra;

namespace Weld.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AjaxMethodAttribute : WeldAttribute
    {
        private readonly ITemplateEngine templateEngine = new RazorTemplateEngine();


        public override string GetCode(MemberInfo member)
        {
            var method = (MethodInfo) member;
            return templateEngine.GetClientMethodCode(method, GetUrl(method));
        }

        protected string GetUrl(MemberInfo method)
        {
            var typeName = method.DeclaringType.Name;
            if ((typeof(Controller).IsAssignableFrom(method.DeclaringType)) && method.DeclaringType.Name.EndsWith("Controller"))
            {
                typeName = typeName.Substring(0, typeName.IndexOf("Controller"));
            }

            return string.IsNullOrEmpty(Url)
                ? string.Format("/{0}/{1}", typeName, method.Name): 
                Url;
        }


       


        public string Url { get; set; }
    }
}