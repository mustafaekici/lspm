using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Shared.Core.Extension
{
    public static class ReflectionExtension
    {
        public static T GetAttribute<T>(this PropertyInfo pi, bool inherit = false) where T : Attribute
        {
            return pi.GetCustomAttributes(typeof(T), inherit).FirstOrDefault() as T;
        }

        public static void SetPropertyValue(this PropertyInfo pi, object Object, object propValue)
        {
            if (!pi.CanWrite)
            {
                throw new ArgumentException("The property's set accessor is not found.", pi.Name);
            }

            if (propValue == null)
            {
                pi.SetValue(Object, null, null);
                return;
            }

            if (pi.PropertyType.IsEnum)
            {
                pi.SetValue(Object, Enum.Parse(pi.PropertyType, propValue.ToString()), null);
                return;
            }
            pi.SetValue(Object, Convert.ChangeType(propValue, pi.PropertyType), null);
        }

        public static bool BaseTypeEquals(this Type instance, string typeName)
        {
            if (instance == null || instance == typeof(object))
                return false;
            var currentType = instance.BaseType;
            while (currentType != null && (currentType != typeof(object)))
            {
                if (currentType.Name.Equals(typeName, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
                currentType = currentType.BaseType;
            }
            return false;
        }

        public static string FormatFields(object instance, string format, string formatFields, char fieldsSeperator = ',')
        {
            if (format.IsNullorWhiteSpace())
                throw new ArgumentException("Format is null");
            if (formatFields.IsNullorWhiteSpace())
                throw new ArgumentException("Format Fields is null");

            var arg = new List<object>();
            var gatewayParams = instance.GetType().GetProperties();
            var fields = formatFields.Split(fieldsSeperator);
            foreach (var f in fields)
            {
                var prop = gatewayParams.FirstOrDefault(w => w.Name.Equals(f, StringComparison.OrdinalIgnoreCase));
                if (prop == null)
                    throw new ArgumentException("The Field {0} not found".FormatString(f));
                var val = prop.GetValue(instance, null);
                arg.Add(val);
            }
            return String.Format(format, arg.ToArray());
        }

        public static bool IsProperyExists(dynamic obj, string name)
        {
            if (obj is ExpandoObject)
            {
                return ((IDictionary<string, Object>)obj).ContainsKey(name);
            }
            return obj.GetType().GetProperty(name) != null;
        }

        public static T Clone<T>(this T source) where T : class, new()
        {
            T dest = new T();
            foreach (PropertyInfo pi in source.GetType().GetProperties())
            {
                foreach (PropertyInfo pi2 in dest.GetType().GetProperties())
                {
                    try
                    {
                        if (pi2.Name == pi.Name)
                        {
                            pi2.SetValue(dest, pi.GetValue(source, null), null);

                            break;
                        }
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }
            return dest;
        }

        public static string MemberAccessToString(Expression expression)
        {
            var body = (expression is LambdaExpression)
                ? ((LambdaExpression)expression).Body
                : expression;
            var me = (MemberExpression)(body.NodeType == ExpressionType.Convert
                ? (body as UnaryExpression).Operand
                : body);
            var result = new StringBuilder();
            MemberAccessToString(me, result);
            return result.ToString();
        }

        private static void MemberAccessToString(MemberExpression expression, StringBuilder result)
        {
            if ((null != expression.Expression) && (expression.Expression is MemberExpression))
            {
                MemberAccessToString((MemberExpression)expression.Expression, result);
                result.Append('.');
            }
            result.Append(expression.Member.Name);
        }

        public static Dictionary<PropertyInfo, T> GetPropertiesWithAttibute<T>(object target) where T : Attribute
        {
            var result = new Dictionary<PropertyInfo, T>();
            if (null != target)
            {
                var props = target.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (var prop in props)
                {
                    var attr = (T)Attribute.GetCustomAttribute(prop, typeof(T));
                    if (null != attr)
                    {
                        result.Add(prop, attr);
                    }
                }
            }
            return result;
        }


        public static T ToObject<T>(this KeyValuePair<string, string>[] keyValueParams) where T : class, new()
        {
            var model = new T();

            PropertyInfo[] properties = model.GetType().GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (!keyValueParams.Any(x => x.Key.Equals(property.Name, StringComparison.InvariantCultureIgnoreCase)))
                    continue;

                KeyValuePair<string, string> item = keyValueParams.First(x => x.Key.Equals(property.Name, StringComparison.InvariantCultureIgnoreCase));

                // Find which property type (int, string, double? etc) the CURRENT property is...
                Type tPropertyType = model.GetType().GetProperty(property.Name).PropertyType;

                // Fix nullables...
                Type newT = Nullable.GetUnderlyingType(tPropertyType) ?? tPropertyType;

                // ...and change the type
                object newA = Convert.ChangeType(item.Value, newT);
                model.GetType().GetProperty(property.Name).SetValue(model, newA, null);
            }

            return model;
        }

    }
}
