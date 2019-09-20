using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Core.Extension
{
    public static class DateTimeExtension
    {
        public static DateTime PreviousWorkDay(this DateTime value)
        {
            var result = value;
            do
            {
                result = result.AddDays(-1);
            } while (result.DayOfWeek == DayOfWeek.Saturday || value.DayOfWeek == DayOfWeek.Sunday);

            return result;
        }

        public static DateTime ClosestWorkDay(this DateTime value)
        {
            var result = value;
            if (result.DayOfWeek == DayOfWeek.Saturday)
            {
                result = result.AddDays(-1);
            }
            else if (result.DayOfWeek == DayOfWeek.Sunday)
            {
                result = result.AddDays(1);
            }
            return result;
        }

        public static DateTime ToSpecificDateTime(this DateTime value, string timeZoneId)
        {
            return string.IsNullOrEmpty(timeZoneId) ? value : TimeZoneInfo.ConvertTimeFromUtc(value, TimeZoneInfo.FindSystemTimeZoneById(timeZoneId));
        }
    }
}
