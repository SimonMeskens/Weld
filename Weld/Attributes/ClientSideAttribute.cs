using System;
using System.Reflection;
using Weld.Infra;

namespace Weld.Attributes
{
    [AttributeUsage(AttributeTargets.Property|AttributeTargets.Field,AllowMultiple = false )]
    public class ClientSideAttribute : WeldAttribute
    {
        public override string GetCode(MemberInfo method)
        {
            var fieldInfo = (FieldInfo)method;
            //quote the value if string
            var rawConstantValue = fieldInfo.FieldType == typeof (string)
                                       ? "\""+ fieldInfo.GetRawConstantValue() +"\""
                                       : fieldInfo.GetRawConstantValue();
            return string.Format("    public static {0}: {2} = {1};\r\n", method.Name,rawConstantValue,TypeMapper.GetTypeScriptType(fieldInfo.FieldType));
        }

    }
}