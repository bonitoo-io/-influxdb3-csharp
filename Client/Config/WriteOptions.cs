using System;
using System.Collections.Generic;
using InfluxDB3.Client.Write;

namespace InfluxDB3.Client.Config;

/// <summary>
/// The WriteOptions class holds the configuration for writing data to InfluxDB.
///
/// You can configure following options:
/// - Precision: The default precision to use for the timestamp of points if no precision is specified in the write API call.
/// - GzipThreshold: The threshold in bytes for gzipping the body. The default value is 1000.
///
/// If you want create client with custom options, you can use the following code:
/// <code>
/// using var client = new InfluxDBClient(new ClientConfig
/// {
///     Host = "https://us-east-1-1.aws.cloud2.influxdata.com",
///     Token = "my-token",
///     Organization = "my-org",
///     Database = "my-database",
///     WriteOptions = new WriteOptions
///     {
///         Precision = WritePrecision.S,
///         GzipThreshold = 4096
///     }
/// }); 
/// </code>
/// </summary>
public class WriteOptions : ICloneable
{
    /// <summary>
    /// The default precision to use for the timestamp of points if no precision is specified in the write API call.
    /// </summary>
    public WritePrecision? Precision { get; set; }

    /// <summary>
    /// Tags added to each point during writing. If a point already has a tag with the same key, it is left unchanged.
    /// <example>
    /// <code>
    /// <![CDATA[
    /// var _client = new InfluxDBClient(new InfluxDBClientConfigs
    /// {
    ///     HostUrl = "some-url",
    ///     Organization = "org",
    ///     Database = "database",
    ///     DefaultTags = new Dictionary \<string, string ()
    ///     {
    ///         { "rack", "main" },
    ///     }
    /// });
    /// 
    /// // Writes with rack=main tag
    /// await _client.WritePointAsync(PointData
    ///     .Measurement("cpu")
    ///     .SetField("field", 1)
    /// );
    /// ]]>
    /// </code>
    /// </example>
    /// </summary>
    public Dictionary<string, string>? DefaultTags { get; set; }

    /// <summary>
    /// The threshold in bytes for gzipping the body.
    /// </summary>
    public int GzipThreshold { get; set; }

    public object Clone()
    {
        return this.MemberwiseClone();
    }

    internal static readonly WriteOptions DefaultOptions = new()
    {
        Precision = WritePrecision.Ns,
        GzipThreshold = 1000
    };
}
