using System;

namespace IGDB.Models
{
  public class DataDump
  {
    public string Endpoint { get; set; }
    public string FileName { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
  }
}