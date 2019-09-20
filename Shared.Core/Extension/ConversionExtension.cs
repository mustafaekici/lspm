using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shared.Core.Extension
{
    public static class ConversionExtension
    {
        public static T To<T>(this object obj) where T : struct
        {
            if (obj is T)
                return (T)obj;

            var tbase = Nullable.GetUnderlyingType(typeof(T));
            if (tbase != null)
            {
                if (typeof(T).IsEnum)
                    return (T)Enum.Parse(typeof(T), obj.ToString());

                if (obj == null)
                    return default(T);
                return (T)Convert.ChangeType(obj, tbase);
            }
            else
            {
                return (T)Convert.ChangeType(obj, typeof(T));
            }
        }

        public static List<T> ToList<T>(this object obj, string seperator)
        {
            if (obj == null)
                return new List<T>();

            return (obj as string).Split(seperator.ToCharArray()).Select(x => (T)Convert.ChangeType(x, typeof(T))).ToList();
        }

        public static T To<T>(this object obj, T defvalue) where T : struct
        {
            if (obj is T)
                return (T)obj;

            var tbase = Nullable.GetUnderlyingType(typeof(T));
            if (tbase != null)
            {
                if (obj == null)
                    return defvalue;
                return (T)Convert.ChangeType(obj, tbase);
            }
            else
            {
                return (T)Convert.ChangeType(obj, typeof(T));
            }
        }
    }
}
