namespace IGDB.Models
{
    public class Me : IIdentifier
    {
        public long? Id { get; set; }
        public string Username { get; set; }
        public string Slug { get; set; }
        public string Presentation { get; set; }
        public string AvatarId { get; set; }
        public string BackgroundId { get; set; }
    }
}