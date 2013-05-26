using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using RazorEngine;
using RazorEngine.Templating;
using Weld.Attributes;
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

            //hacky
            var isPost = method.GetCustomAttributes(typeof(HttpPostAttribute), true).Any() || returnType.IsJsonResult() || returnType == typeof(JsonResult);
            model.AjaxMethod = isPost ? "POST" : "";

            var allParameters = string.Join(", ", inputParameters);
            model.Signature = method.Name + "(" + allParameters + ")";



            model.Url = url;
            var inputJsonTuples = method.GetParameters().Select(p => string.Format("{0}: {0}", p.Name));
            model.Data = "{ " + string.Join(", ", inputJsonTuples) + " }";

            
            var template = GetTemplate("ClientMethod");

            
            return RemoveEmptyLines(Razor.Parse(template, model));//.Split("\r\n".ToCharArray(),StringSplitOptions.RemoveEmptyEntries);
            
        }

        public string GetTypeScriptInterface(Type type)
        {
            var template = GetTemplate("TypeScriptInterface");

            //get all public properties 
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var propertyTypes =properties.Select(p => new Tuple<string, string>(p.Name, TypeMapper.GetTypeScriptType(p.PropertyType))).ToList();

            var model = new TypeScriptInterfaceModel
                {
                    TypeName = type.Name,
                    PropertyNamesAndTypeScriptTypes = propertyTypes
                };
            return Razor.Parse(template, model);
        }

        public string GetProxyApi(Type type)
        {
            var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            return "";
        }

        //TODO: remove dup with processor..get this out of templating
        private string GetClassName(Type type)
        {
            return string.Format(type.Name);
        }

        public string GetViewModelCode(Type type)
        {
            var template = GetTemplate("ViewModel");
            var model = new ViewModel
                {
                    ClassName = GetClassName(type), 
                    PropertyNames = GetViewModelPropertyNames(type)
                };

            return Razor.Parse(template, model);
        }

        private IList<string> GetViewModelPropertyNames(Type type)
        {
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var result = new List<string>();

            //if a property is a viewmodel write it out
            foreach (var property in properties)
            {
                if (property.PropertyType.GetCustomAttributes(true).OfType<WeldViewModelAttribute>().Any())
                {
                    var names = GetViewModelPropertyNames(property.PropertyType);
                    result = result.Concat(names.Select(n => property.Name + "_" + n)).ToList();
                }
                else
                {
                    result.Add(property.Name);
                }
            }

            return result;
        }

        public string GetProxyApiGetMethod(MethodInfo method)
        {
            var template = GetTemplate("ProxyApiGetMethod");
            var parameterInfo = method.GetParameters()[0];
            var model = new ProxyApiGetMethod
                {
                    MethodName = method.Name,
                    ParameterName = parameterInfo.Name,
                    ParameterType = TypeMapper.GetTypeScriptType(parameterInfo.ParameterType),
                    ReturnType = TypeMapper.GetTypeScriptType(method.ReturnType),

                };
            return "";
        }

        private string RemoveEmptyLines(string value)
        {
            var lines = value.Split("\r\n".ToCharArray(), StringSplitOptions.None);
            lines = lines.Where(l => !string.IsNullOrEmpty(l.Trim())).ToArray();
            return string.Join("\r\n",lines)+"\r\n";
        }

        private string GetTemplate(string templateName)
        {
            string result;
            var weldTemplatesClientmethodCshtml = "Weld.Templates."+templateName+".cshtml";

            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(weldTemplatesClientmethodCshtml))
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