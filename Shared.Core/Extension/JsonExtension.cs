using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Core.Extension
{
    public static class JsonExtension
    {
        public static T FromJson<T>(this string jsonString)
        {
            return (T)JsonConvert.DeserializeObject(jsonString, typeof(T));
        }
        public static string ToJson(this object[] objs)
        {
            try
            {
                if (objs != null && objs.Length > 0)
                    return JsonConvert.SerializeObject(objs);
            }
            catch (Exception ex)
            {
                throw new JsonException("Cannot convert objects to Json string", ex);
            }

            return string.Empty;
        }
        public static string ToJson(this object obj)
        {
            try
            {
                if (obj != null)
                    return JsonConvert.SerializeObject(obj);
            }
            catch (Exception ex)
            {
                throw new JsonException("Cannot convert object to Json string", ex);
            }

            return string.Empty;
        }
    }
}
