using System;
using System.Numerics;

namespace InfluxDB3.Client.Internal;

internal static class TimestampConverter
{
    private static readonly DateTime EpochStart = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    /// <summary>
    /// Get nano time from Datetime and EpochStart time .
    /// </summary>
    /// <param name="dateTime">the Datetime object</param>
    /// <returns>the time in nanosecond</returns>
    internal static BigInteger GetNanoTime(DateTime dateTime)
    {
        var utcTimestamp = dateTime.Kind switch
        {
            DateTimeKind.Local => dateTime.ToUniversalTime(),
            DateTimeKind.Unspecified => DateTime.SpecifyKind(dateTime, DateTimeKind.Utc),
            _ => dateTime
        };
        return utcTimestamp.Subtract(EpochStart).Ticks * 100;
    }
}