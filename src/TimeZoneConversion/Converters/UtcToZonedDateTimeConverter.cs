using System;
using System.Globalization;
using NodaTime;
using Xamarin.Forms;

namespace TimeZoneConversion.Converters
{
    public class UtcToZonedDateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || value.GetType() != typeof(DateTime))
            {
                return DateTime.MinValue;
            }

            if (parameter == null || parameter.GetType() != typeof(string) || !DateTimeZoneProviders.Tzdb.Ids.Contains((string)parameter))
            {
                return value;
            }

            var dateTime = (TimeZoneInfo.ConvertTime(DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), TimeZoneInfo.FindSystemTimeZoneById));


            var timeZone = DateTimeZoneProviders.Tzdb[(string)parameter];
            var utcDateTime = DateTime.SpecifyKind((DateTime)value, DateTimeKind.Utc);
            var zonedDateTime = Instant.FromDateTimeUtc(utcDateTime).InZone(timeZone).ToDateTimeUnspecified();

            return zonedDateTime;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || value.GetType() != typeof(DateTime))
            {
                return DateTime.MinValue;
            }

            // If should be set to DateTimeKind.Unspecified in Convert
            if (((DateTime)value).Kind != DateTimeKind.Unspecified)
            {
                return value;
            }

            if (parameter == null || parameter.GetType() != typeof(string) || !DateTimeZoneProviders.Tzdb.Ids.Contains((string)parameter))
            {
                return value;
            }

            var localDateTime = LocalDateTime.FromDateTime((DateTime)value);
            var timeZone = DateTimeZoneProviders.Tzdb[(string)parameter];

            var zonedDbDateTime = timeZone.AtLeniently(localDateTime);
            return zonedDbDateTime.ToDateTimeUtc();

        }
    }
}
