using System;
using System.Reflection;

namespace Weld.Infra
{
    public interface ITemplateEngine
    {
        string GetClientMethodCode(MethodInfo method,string url);
        string GetTypeScriptInterface(Type type);
        string GetProxyApi(Type type);
        string GetViewModelCode(Type type);
    }
}