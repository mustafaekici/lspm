using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Shared.Contracts.Attributes;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Shared.Contracts.Extensions
{
    public static class Extensions
    {
        public static string ToJson(this object obj, JsonSerializerSettings settings = null)
        {
            var serializerSettings = settings ?? new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Include,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            serializerSettings.Converters.Add(new StringEnumConverter());
            return JsonConvert.SerializeObject(obj, serializerSettings);
        }

        public static Type PropertyExactType(this PropertyInfo propertyInfo)
        {
            return Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;
        }

        public static string DisplayName(this MemberInfo member)
        {
            var contractMeta = member.GetCustomAttribute<ContractMetaAttribute>();
            return contractMeta != null ? contractMeta.DisplayName : member.Name;
        }

        public static string DisplayName(this Type type)
        {
            var contractMeta = type.GetCustomAttribute<ContractMetaAttribute>();
            return contractMeta != null ? contractMeta.DisplayName : type.Name;
        }

        public static string DisplayName(this Enum enumValue)
        {
            var declaredField = enumValue
                .GetType()
                .GetTypeInfo()
                .GetDeclaredField(enumValue.ToString());

            var contractMeta = declaredField == null ? null : declaredField.GetCustomAttribute<ContractMetaAttribute>();

            return contractMeta != null ? contractMeta.DisplayName : enumValue.ToString();
        }

        public static TEnum ToEnum<TEnum>(this object value) where TEnum : struct, IConvertible
        {
            if (!typeof(TEnum).IsEnum) throw new ArgumentException("T must be an enumerated type");
            if (value == null) return default(TEnum);

            return (TEnum)Enum.Parse(typeof(TEnum), value.ToString());
        }

        public static Enum ToEnum(this object value, Type enumType)
        {
            return (Enum)Enum.Parse(enumType, value.ToString());
        }

        public static string ToCamelCaseString(this object obj)
        {
            if (obj == null)
            {
                return null;
            }

            if (obj.ToString().Length == 0 || obj.GetType() == typeof(object))
            {
                return string.Empty;
            }

            var objString = obj.ToString();
            var firstLetter = objString[0].ToString().ToLowerInvariant();

            return firstLetter + objString.Substring(1);
        }

        public static bool IsNumericType(this Type type)
        {
            var checkedType = type;
            if (type.IsNullableType())
            {
                checkedType = Nullable.GetUnderlyingType(type);
            }

            // Enums are detected as Int32
            if (checkedType.IsEnum)
            {
                return false;
            }

            switch (Type.GetTypeCode(checkedType))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                default:
                    return false;
            }
        }

        public static bool IsNullableType(this Type type)
        {
            return Nullable.GetUnderlyingType(type) != null;
        }

        public static bool IsConfigurable(this MemberInfo member)
        {
            return member.GetCustomAttribute<FilterableAttribute>() != null;
        }

        public static string RemoveAllSpaces(this string value)
        {
            return value.Replace(" ", string.Empty);
        }
    }
}
