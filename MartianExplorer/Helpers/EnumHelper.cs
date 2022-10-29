using System;
using System.ComponentModel.DataAnnotations;

namespace MartianExplorer.Helpers
{
    public static class EnumHelper
    {
        public static bool TryGetValueFromDisplay<T>(this string displayName, out T value) where T : Enum
        {
            var type = typeof(T);

            foreach (var field in type.GetFields())
            {
                if (Attribute.GetCustomAttribute(field, typeof(DisplayAttribute)) is DisplayAttribute attribute)
                {
                    if (attribute.Name == displayName)
                    {
                        value = (T)field.GetValue(null);
                        return true;
                    }
                }

                if (field.Name == displayName)
                {
                    value = (T)field.GetValue(null);
                    return true;
                }
            }
            value = default;
            return false;
        }

        public static string GetDisplay(this Enum en)
        {
            var type = en.GetType();

            var memInfo = type.GetMember(en.ToString());

            if(memInfo != null && memInfo.Length > 0)
            {
                var attrs = memInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false);

                if(attrs != null && attrs.Length > 0)
                {
                    return ((DisplayAttribute)attrs[0]).Name;
                }
            }

            return en.ToString();
        }
    }
}
