using System;
using System.Collections.Generic;

namespace IGDB.Models
{
  public class DataDumpEndpoint
  {
    public string S3Url { get; set; }
    public string Endpoint { get; set; }
    public string FileName { get; set; }
    public long SizeBytes { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public string SchemaVersion { get; set; }

    /// <summary>
    /// Dictionary representing the schema of the CSV file. Tied to SchemaVersion.
    /// </summary>
    /// <remarks>
    /// Example:
    /// - id: "LONG"
    /// - name: "STRING"
    /// - created_at: "TIMESTAMP"
    /// - franchises: "LONG[]"
    /// - total_rating: "DOUBLE"
    /// - total_rating_count: "INTEGER" 
    /// </remarks>
    public Dictionary<string, string> Schema { get; set; }
  }
}