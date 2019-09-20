using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Shared.Core.Extension
{
    public static class DictionaryExtension
    {
        public static T ToObject<T>(this IDictionary<string, object> source) where T : class, new()
        {
            var obj = new T();
            var someObjectType = obj.GetType();

            foreach (var item in source)
            {
                someObjectType.GetProperty(item.Key).SetValue(obj, item.Value, null);
            }
            return obj;
        }

        public static dynamic ToObject(this IDictionary<string, object> source)
        {
            var obj = new ExpandoObject();
            var someObjectType = obj.GetType();
            foreach (var item in source)
            {
                someObjectType.GetProperty(item.Key).SetValue(obj, item.Value, null);
            }
            return obj;
        }
    }
}
