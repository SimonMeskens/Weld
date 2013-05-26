using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Http;
using Weld.Attributes;
using Weld.Extensions;
using Weld.Infra;

namespace Weld
{


    /// <summary>
    /// TODO: make interface and extendible
    /// </summary>
    public class TypeScriptProcessor
    {
        public ProcessResult Process(Type type)
        {
            if (type.GetCustomAttributes(true).OfType<WeldViewModelAttribute>().Any())
            {
                WeldViewModelAttribute attribute = type.GetCustomAttributes(true).OfType<WeldViewModelAttribute>().FirstOrDefault();
                if (attribute != null)
                {
                    var fileName = GetFileName(type);
                    
                    var content = GetIncludes() + Environment.NewLine + attribute.GetCode(type);
                    
                    return new ProcessResult
                        {
                            Content = content, 
                            FileName = fileName
                        };
                }
            }


            //parse attibutes..and return typescript
            var members = type.GetMembers(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

            var targetMembers = new List<MemberInfo>();
            foreach (MemberInfo c in members)
            {
                var customAttributes = c.GetCustomAttributes(true);

                if (customAttributes.OfType<WeldAttribute>().Any())
                {
                    targetMembers.Add(c);
                }
            }

            return targetMembers.Any() ? 
                GenerateCode(type,targetMembers) : 
                null;
        }

        private static string GetIncludes()
        {
            //TODO: make configurable
            return "/// <reference path=\"../typings/jquery/jquery.d.ts\" />";
        }

        private ProcessResult GenerateCode(Type type, IList<MemberInfo> targetMembers)
        {
            var fileName = GetFileName(type);
            var className = GetClassName(type);


            


            var contentBuilder = new StringBuilder();
            

            contentBuilder.AppendLine(GetIncludes());
            contentBuilder.AppendLineFormat("class {0}", className);
            contentBuilder.AppendLine("{");



            foreach (var method in targetMembers)
            {
                //get applicable attribute(s)
                foreach (var attribute in method.GetCustomAttributes(true).OfType<WeldAttribute>())
                {
                    contentBuilder.Append(attribute.GetCode(method));
                }
            }

            contentBuilder.AppendLine("}");

            AppendInterfaces(targetMembers, contentBuilder);

            return new ProcessResult
                {
                    FileName = fileName,
                    Content = contentBuilder.ToString()
                };
        }

        private static void AppendInterfaces(IList<MemberInfo> targetMembers, StringBuilder contentBuilder)
        {
            var typeScriptJSonInterfaces = GetTypeScriptJSonInterfaces(targetMembers);
            if (!string.IsNullOrEmpty(typeScriptJSonInterfaces))
            {
                contentBuilder.AppendLine();
                contentBuilder.Append(typeScriptJSonInterfaces);    
            }
        }

        /// <summary>
        /// TODO : not only JSON stuff.
        /// </summary>
        /// <param name="targetMembers"></param>
        /// <returns></returns>
        private static string GetTypeScriptJSonInterfaces(IEnumerable<MemberInfo> targetMembers)
        {
            var engine = new RazorTemplateEngine();
            var methods = targetMembers.OfType<MethodInfo>().ToList();
            var returnTypes = methods.Select(m => m.ReturnType).Distinct().ToList();
            var parameterTypes = methods.SelectMany(m => m.GetParameters()).Select(p => p.ParameterType).Distinct().ToList();
            var relevantTypes = returnTypes.Concat(parameterTypes).Where(t => !t.FullName.StartsWith("System")).ToList();
            var result = new StringBuilder();

            foreach (var relevantType in relevantTypes.Where(t => t.IsJsonResult()))
            {
                var genericArgument = relevantType.GetGenericArguments()[0];
                result.Append(engine.GetTypeScriptInterface(genericArgument));
            }
            return result.ToString();
        }

        private string GetClassName(Type type)
        {
            return string.Format(type.Name);
        }

        private string GetFileName(Type type)
        {
            return string.Format("{0}.ts",type.Name);
        }

        //TODO: factor into other (base?) class as this is not specific for TypeScript
        public IList<ProcessResult> ProcessAssembly(Assembly assembly)
        {
            return assembly.GetTypes().Select(Process)
                .Where(typeResult => typeResult != null)
                .ToList();
        }
    }
}
