using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Muljin.JsonConverters
{
    /// <summary>
    /// Custom converter for timespan used for hours and minutes.
    /// Converts from format hh:mm to TimeSpan hours and minutes
    /// </summary>
    public class TimeSpanJsonConverter : JsonConverter<TimeSpan>
    {
        public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var ts = reader.GetString();
            if (String.IsNullOrWhiteSpace(ts))
            {
                return TimeSpan.FromHours(0);
            }

            //currently only supports hours and minutes
            var segs = ts.Split(':');
            int hours;
            int mins = 0;

            hours = int.Parse(segs[0]);
            if (segs.Length > 1)
            {
                mins = int.Parse(segs[1]);
            }

            var res = TimeSpan.FromHours(hours);
            res += TimeSpan.FromMinutes(mins);

            return res;
        }

        public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
        {
            var mins = value.Minutes;
            var hours = (int)Math.Floor(value.TotalHours);
            writer.WriteStringValue($"{hours}:{mins}");
        }
    }
}
