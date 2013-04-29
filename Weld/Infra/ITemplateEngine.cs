using System.Reflection;

namespace Weld.Infra
{
    public interface ITemplateEngine
    {
        string GetClientMethodCode(MethodInfo method,string url);
    }
}