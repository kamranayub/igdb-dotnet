using System;

namespace IGDB.Models
{
  public class Company : ITimestamps, IIdentifier, IHasChecksum
  {
    public DateTimeOffset? ChangeDate { get; set; }
    public IdentityOrValue<DateFormat> ChangeDateFormat { get; set; }
    public IdentityOrValue<Company> ChangedCompanyId { get; set; }
    public string Checksum { get; set; }

    /// <summary>
    /// ISO 3166-1 country code
    /// </summary>
    public int? Country { get; set; }

    public DateTimeOffset? CreatedAt { get; set; }

    public string Description { get; set; }

    public IdentitiesOrValues<Game> Developed { get; set; }
    public long? Id { get; set; }
    public IdentityOrValue<CompanyLogo> Logo { get; set; }

    public string Name { get; set; }
    public IdentityOrValue<Company> Parent { get; set; }
    public IdentitiesOrValues<Game> Published { get; set; }
    public string Slug { get; set; }
    public DateTimeOffset? StartDate { get; set; }
    public IdentityOrValue<DateFormat> StartDateFormat { get; set; }
    public IdentityOrValue<CompanyStatus> Status { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public string Url { get; set; }
    public IdentitiesOrValues<CompanyWebsite> Websites { get; set; }
  }
}