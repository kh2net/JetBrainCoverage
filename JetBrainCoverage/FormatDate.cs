using System;

namespace JetBrainCoverage
{
    public class FormatDate
    {
        public static DateTime ParseDate(string dateString, string format)
        {
            if (string.IsNullOrEmpty(dateString) || string.IsNullOrEmpty(format))
                throw new ArgumentNullException();
            return DateTime.ParseExact(dateString, format, null);
        }

        public static Type GetType(string typeName)
        {

            if (string.IsNullOrEmpty(typeName))
                return null;

            Type type = Type.GetType(typeName);

            return type;
        }

        public static string FormatDate2String(DateTime date, string format)
        {
            return date.ToString(format);
        }
    }
}