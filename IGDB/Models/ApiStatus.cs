using System;

namespace IGDB.Models
{
  public class ApiStatus
  {
    public bool Authorized { get; set; }
    public string Plan { get; set; }
    public UsageReports UsageReports { get; set; }
  }

  public class UsageReports
  {
    public UsageReport UsageReport { get; set; }
  }

  public class UsageReport
  {
    public string Metric { get; set; }
    public string Period { get; set; }
    public DateTime PeriodStart { get; set; }
    public DateTime PeriodEnd { get; set; }
    public int MaxValue { get; set; }
    public int CurrentValue { get; set; }
  }
}