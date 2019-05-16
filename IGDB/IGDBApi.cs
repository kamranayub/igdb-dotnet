using System;
using System.Threading.Tasks;
using RestEase;

namespace IGDB
{
    [Header("Accept", "application/json")]
    public interface IGDBApi
    {
        [Header("user-key")]
        string ApiKey { get; set; }

        [Post("/games")]
        Task<Game[]> GetGamesAsync([Body] string query = null);
    }
}
