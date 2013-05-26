using System;
using System.Web.Mvc;

namespace Weld.Infra
{
    public class TypeMapper
    {
        public static string GetTypeScriptType(Type parameterType)
        {
            if (parameterType.IsJsonResult())
            {
                return parameterType.GetGenericArguments()[0].Name;
            }

            if (parameterType.IsArray)
            {
                return GetTypeScriptType(parameterType.GetElementType()) + "[]";
            }


            if (parameterType == typeof(int))
            {
                return "number";
            }
            if (parameterType == typeof(string))
            {
                return "string";
            }
            if (parameterType == typeof(PartialViewResult) || parameterType == typeof(ContentResult))
            {
                return "string";
            }
            if (parameterType == typeof(bool))
            {
                return "bool";
            }
            return "any";
        }
    }
}