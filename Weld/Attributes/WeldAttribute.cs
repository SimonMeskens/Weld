using System;
using System.Reflection;

namespace Weld.Attributes
{
    public abstract class WeldAttribute : Attribute
    {
        public abstract string GetCode(MemberInfo method);

        
    }
}