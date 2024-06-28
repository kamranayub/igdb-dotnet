using System;
using System.Linq;
using System.Net.Http;
using RestEase;

namespace IGDB
{
  public static class ResponseExtensions
  {
    private const string CountHeader = "x-count";

    /// <summary>
    /// The value of the X-Count header for IGDB query endpoints, if it exists.
    /// </summary>
    public static int? GetQueryCount<T>(this Response<T> response)
    {
      return int.TryParse(response.ResponseMessage.Headers.GetValues(CountHeader).First(), out var count) ? count : (int?)null;
    }
  }
}