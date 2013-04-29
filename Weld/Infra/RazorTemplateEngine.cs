using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using RazorEngine;
using RazorEngine.Templating;
using Weld.Templates;

namespace Weld.Infra
{
    public class RazorTemplateEngine : ITemplateEngine
    {
        public string GetClientMethodCode(MethodInfo method, string url)
        {
            var model = new ClientMethodModel();

            var parameterInfos = method.GetParameters();
            var inputParameters = parameterInfos.Select(p => string.Format("{0}: {1}", p.Name, TypeMapper.GetTypeScriptType(p.ParameterType)))
                    .ToList();
            
            model.Traditional = parameterInfos.Any(p => p.ParameterType.IsArray);

            var returnType = method.ReturnType;
            if (returnType.Name != "Void")
            {
                var onSucces = "callback: (data: " + TypeMapper.GetTypeScriptType(returnType) + ") => any";
                inputParameters.Add(onSucces);
                model.OnSucces = "callback";
            }

            var isPost = method.GetCustomAttributes(typeof(HttpPostAttribute), true).Any();
            model.AjaxMethod = isPost ? "POST" : "";

            var allParameters = string.Join(", ", inputParameters);
            model.Signature = method.Name + "(" + allParameters + ")";



            model.Url = url;
            var inputJsonTuples = method.GetParameters().Select(p => string.Format("{0}: {0}", p.Name));
            model.Data = "{ " + string.Join(", ", inputJsonTuples) + " }";

            
            var template = GetTemplate();

            
            return RemoveEmptyLines(Razor.Parse(template, model));//.Split("\r\n".ToCharArray(),StringSplitOptions.RemoveEmptyEntries);
            
        }
        private string RemoveEmptyLines(string value)
        {
            var lines = value.Split("\r\n".ToCharArray(), StringSplitOptions.None);
            lines = lines.Where(l => !string.IsNullOrEmpty(l.Trim())).ToArray();
            return string.Join("\r\n",lines)+"\r\n";
        }

        private string GetTemplate()
        {
            string result;
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Weld.Templates.ClientMethod.cshtml"))
            {
                using (var reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }    
            }
            
            return result;
        }
    }
}