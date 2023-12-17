using System;
using System.Linq;
using System.ComponentModel;

namespace Albatross.Tools
{
    public static class EnumHelper
    {
        public static (T Value, string Name)[] GetValues<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T))
                .Cast<T>()
                .Select(value => (Value: value, Name: GetEnumName(value)))
                .ToArray();
        }

        public static string GetEnumName(Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
}
