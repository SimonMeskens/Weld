using System;
using Weld.Infra;

namespace Weld.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class WeldViewModelAttribute : Attribute
    {
        private readonly ITemplateEngine templateEngine = new RazorTemplateEngine();

        public string GetCode(Type type)
        {
            var result = new ProcessResult();
            return templateEngine.GetViewModelCode(type);
        }
    }
}