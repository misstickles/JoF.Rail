namespace JoF.Rail.Core.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;

    public static class EnumExtensions
    {
        public static string ToDescription<TEnum>(this TEnum enumValue)
        {
            var field = enumValue.GetType().GetField(enumValue.ToString());
            var attrs = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attrs.Length > 0 ? attrs[0].Description : enumValue.ToString();
        }

        public static string ToDisplayName<TEnum>(this TEnum enumValue)
        {
            var field = enumValue.GetType().GetField(enumValue.ToString());
            var attrs = (DisplayNameAttribute[])field.GetCustomAttributes(typeof(DisplayNameAttribute), false);

            return attrs.Length > 0 ? attrs[0].DisplayName : enumValue.ToString();
        }

        public static TEnum ToEnum<TEnum>(this string description)
            where TEnum : Enum
        {
            var type = typeof(TEnum);

            foreach (var field in type.GetFields())
            {
                var attr = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

                if (attr == null) continue;

                if (attr.Description == description)
                {
                    return (TEnum)field.GetValue(null);
                }
            }

            return default;
        }
    }
}
