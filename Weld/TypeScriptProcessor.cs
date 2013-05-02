using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Text;
using Weld.Attributes;
using Weld.Extensions;

namespace Weld
{


    /// <summary>
    /// TODO: make interface and extendible
    /// </summary>
    public class TypeScriptProcessor
    {
        public ProcessResult Process(Type type)
        {
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

        private ProcessResult GenerateCode(Type type, IEnumerable<MemberInfo> targetMembers)
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

            contentBuilder.Append("}");

            return new ProcessResult
                {
                    FileName = fileName,
                    Content = contentBuilder.ToString()
                };
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
