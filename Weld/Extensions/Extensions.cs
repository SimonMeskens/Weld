using System.Text;

namespace Weld.Extensions
{
    public static class Extensions
    {
        public static void AppendLineFormat(this StringBuilder stringBuilder, string format,params object[] args)
        {
            stringBuilder.AppendLine(string.Format(format, args));
        }

        
    }
}