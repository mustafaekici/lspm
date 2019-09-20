using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Shared.Core.Extension
{
    public static class StringExtension
    {
        public static string FormatString(this string value, params object[] args)
        {
            return string.Format(value, args);
        }

        public static string FormatString(this string value, object arg)
        {
            return string.Format(value, arg);
        }

        public static string FormatStringAuto(this string seperator, params object[] arg)
        {
            return string.Join(seperator, arg);
        }

        public static string Join<T>(this IEnumerable<T> source, string sep)
        {
            if (source == null)
                return null;

            return string.Join(sep, source.ToArray()); // You can erase `.ToArray()` if you're using .Net 4
        }

        public static bool IsNull(this object value)
        {
            return value == null;
        }

        public static bool IsNullorWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public static bool IsNotNullorWhiteSpace(this string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }

        public static string IsNullorWhiteSpace(this string value, string defaultValue)
        {
            return string.IsNullOrWhiteSpace(value) ? defaultValue : value;
        }

        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static string IsNullOrEmpty(this string value, string defaultValue)
        {
            return string.IsNullOrEmpty(value) ? defaultValue : value;
        }

        public static bool IsNumeric(this string value)
        {
            return Regex.IsMatch(value, @"[0-9]", RegexOptions.Compiled);
        }

        public static string Repeat(this char input, int count)
        {
            return new string(input, count);
        }

        public static string Truncate(this string value, int maxLength)
        {
            if (value.IsNullOrEmpty()) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }

        public static string ToBase64(this string value, Encoding encoding = null)
        {
            if (value.IsNullorWhiteSpace()) return value;
            return Convert.ToBase64String((encoding ?? Encoding.UTF8).GetBytes(value));
        }

        public static string FromBase64(this string value, Encoding encoding = null)
        {
            if (value.IsNullorWhiteSpace()) return value;
            return (encoding ?? Encoding.UTF8).GetString(Convert.FromBase64String(value));
        }

        public static string CapitaliseName(this string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            const string targets = "- ";
            var culture = new CultureInfo("en-US");
            var capitalise = true;
            var result = new StringBuilder(text.Length);
            foreach (var c in text)
            {
                if (capitalise)
                {
                    result.Append(char.ToUpper(c, culture));
                    capitalise = false;
                }
                else
                {
                    if (targets.Contains(c.ToString()))
                        capitalise = true;

                    result.Append(c);
                }
            }
            return result.ToString();
        }

        public static string ExtractBetween(this string text, string start, string end,
            StringComparison stringComparison = StringComparison.InvariantCultureIgnoreCase)
        {
            int startIndex = text.IndexOf(start, stringComparison);
            if (startIndex < 0) return string.Empty;
            startIndex += start.Length;

            int endIndex = text.IndexOf(end, startIndex, stringComparison);
            if (endIndex < 0) return string.Empty;

            return text.Substring(startIndex, endIndex - startIndex);
        }

        public static string EmptyIfNull(this string source)
        {
            return source == null ? string.Empty : source;
        }

        public static string ConvertToSkype(this string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                return null;
            }
            return "skype:" + source.Split('-')[0].Replace(" ", "").Replace(")", "").Replace("(", "").Substring(1) +
                   "?call";
        }

        public static string FormatAsHtmlId(this string name)
        {
            return string.IsNullOrEmpty(name) ? string.Empty : Regex.Replace(name, "[^a-zA-Z0-9-:]", "_");
        }

        public static string FormatAsHtmlName(this string name)
        {
            return string.IsNullOrEmpty(name) ? string.Empty : Regex.Replace(name, "[^a-zA-Z0-9.-:]", "_");
        }

        public static string SurroundWith(this string value, string start, string end)
        {
            return string.Concat(start, value, end);
        }


        public static int ToIntDef(this string s, int @default)
        {
            int number;
            return int.TryParse(s, out number) ? number : @default;
        }

        public static int? ToIntDefNull(this string s)
        {
            int number;
            return int.TryParse(s, out number) ? (int?)number : null;
        }

        public static float ToFloatDef(this string s, float @default)
        {
            float number;
            return float.TryParse(s, out number) ? number : @default;
        }

        public static float? ToFloatDefNull(this string s)
        {
            float number;
            return float.TryParse(s, out number) ? (float?)number : null;
        }

        public static double ToDoubleDef(this string s, double @default)
        {
            double number;
            return double.TryParse(s, out number) ? number : @default;
        }

        public static double? ToDoubleDefNull(this string s)
        {
            double number;
            return double.TryParse(s, out number) ? (double?)number : null;
        }

        public static decimal ToDecimalDef(this string s, decimal @default)
        {
            decimal number;
            return decimal.TryParse(s, out number) ? number : @default;
        }

        public static decimal? ToDecimalDefNull(this string s)
        {
            decimal number;
            return decimal.TryParse(s, out number) ? (decimal?)number : null;
        }

        public static DateTime? ToDateTimeDefNull(this string s)
        {
            DateTime date;
            if (DateTime.TryParse(s, out date))
                return date;
            return null;
        }

        public static Guid ToGuidDef(this string s, Guid @default)
        {
            Guid guid;
            return Guid.TryParse(s, out guid) ? guid : @default;
        }

        public static Guid? ToGuidDefNull(this string s)
        {
            Guid guid;
            return Guid.TryParse(s, out guid) ? (Guid?)guid : null;
        }

        public static string TrimEnd(this string input, string suffixToRemove)
        {
            if (input != null && suffixToRemove != null && input.EndsWith(suffixToRemove))
            {
                return input.Substring(0, input.Length - suffixToRemove.Length);
            }
            else return input;
        }

        public static string ToJson(this object obj, JsonSerializerSettings settings = null)
        {
            var _settings = settings ?? new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Include,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
            };
            _settings.Converters.Add(new StringEnumConverter());
            return JsonConvert.SerializeObject(obj, _settings);
        }
    }
}
