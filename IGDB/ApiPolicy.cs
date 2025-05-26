using System;
using System.Net.Http;
using System.Threading.Tasks;
using Polly;
using Polly.Bulkhead;
using Polly.RateLimit;

namespace IGDB
{
  public static class ApiPolicy
  {
    private static readonly Random _jitter = new Random();
    private const int MaxRetries = 3;
    private const double RetryDelayBaseSeconds = 0.5;
    private const int MaxParallelization = 6;
    private const int MaxQueuingActions = 32;
    private const int MaxRateLimit = 4;
    private const int JitterMs = 500;
    private static readonly TimeSpan RateLimitPeriod = TimeSpan.FromMilliseconds(900);

    /// <summary>
    /// Default API policy for handling HTTP requests to IGDB.
    /// 
    /// This policy includes:
    /// - Retry logic for rate limit and bulkhead exceptions with exponential backoff and jitter.
    /// - Bulkhead isolation to limit the number of concurrent requests.
    /// - Rate limiting to control the request rate.
    /// 
    /// The retry logic will attempt to retry up to 3 times with an exponential backoff strategy,
    /// adding a random jitter of up to ±500ms to avoid thundering herd problems.
    /// </summary>
    public static readonly IAsyncPolicy<HttpResponseMessage> DefaultApiPolicy
        = Policy.WrapAsync(
          Policy<HttpResponseMessage>.Handle<RateLimitRejectedException>()
            .Or<BulkheadRejectedException>()
            .WaitAndRetryAsync(
              retryCount: MaxRetries,
              sleepDurationProvider: (retryAttempt) =>
              {
                var backOff = TimeSpan.FromSeconds(RetryDelayBaseSeconds * Math.Pow(2, retryAttempt - 1));
                var jitter = TimeSpan.FromMilliseconds(_jitter.Next(-JitterMs, JitterMs));
                return backOff + jitter;
              },
              onRetry: (_, __, ___) => { }
            ),
            Policy.BulkheadAsync<HttpResponseMessage>(maxParallelization: MaxParallelization, maxQueuingActions: MaxQueuingActions),
            Policy.RateLimitAsync<HttpResponseMessage>(MaxRateLimit, RateLimitPeriod)
        );
  }
}