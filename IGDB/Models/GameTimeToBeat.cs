using System;

namespace IGDB.Models
{

  public class GameTimeToBeat : IHasChecksum, IIdentifier, ITimestamps
  {
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }

    public long? Id { get; set; }

    public int GameId { get; set; }

    /// <summary>
    /// Total number of time to beat submissions for this game
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// Average time (in seconds) to finish the game to its credits without spending notable time on extras such as side quests.
    /// </summary>
    public int? Hastily { get; set; }

    /// <summary>
    /// Average time (in seconds) to finish the game while mixing in some extras such as side quests without being overly thorough.
    /// </summary>
    public int? Normally { get; set; }

    /// <summary>
    /// Average time (in seconds) to finish the game to 100% completion.
    /// </summary>
    public int? Completely { get; set; }

    public string Checksum { get; set; }
  }
}