using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weld.Infra
{
    public static class TypeExtensions
    {
        public static bool IsJsonResult(this Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition().Name == "JsonResult`1";
        }
    }
}
