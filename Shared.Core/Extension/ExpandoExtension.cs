using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Shared.Core.Extension
{
    public static class ExpandoExtension
    {
        public static dynamic ToExpandoObject(this object obj)
        {
            IDictionary<string, object> result = new ExpandoObject();
            foreach (var p in obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(w => w.CanRead))
            {
                result[p.Name] = p.GetValue(obj, null);
            }
            return result;
        }

        public static bool HasProperty(dynamic obj, string name)
        {
            Type objType = obj.GetType();
            if (objType == typeof(ExpandoObject))
            {
                return ((IDictionary<string, object>)obj).ContainsKey(name);
            }
            return objType.GetProperty(name) != null;
        }
    }
}
