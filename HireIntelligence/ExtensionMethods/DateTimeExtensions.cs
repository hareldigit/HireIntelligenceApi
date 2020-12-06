using HireIntelligence;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HireIntelligenceService.ExtensionMethods
{
    public static class DateTimeExtensions
    {
        public static DateTime UnixTimeStampToDateTime(this double unixTimeStamp)
        {
            var datetime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            datetime = datetime.AddSeconds(unixTimeStamp);
            return datetime;
        }

        private static TimeSpan GetTimeZoneOffset(DateTime datetime)
        {
            var timeZoneId = Startup.StaticConfig.GetValue<string>("HireIntelligenceApp:TimeZoneId");
            var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            var offset = timeZoneInfo.GetUtcOffset(datetime);
            return offset;
        }

        public static DateTime StartOfDay(this DateTime theDate)
        {
            return theDate.Date;
        }

        public static DateTime EndOfDay(this DateTime theDate)
        {
            return theDate.Date.AddDays(1).AddTicks(-1);
        }
    }
}
