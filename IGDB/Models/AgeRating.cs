namespace IGDB.Models
{
    public class AgeRating : IIdentifier
    {
        public AgeRatingCategory? Category { get; set; }
        public IdentitiesOrValues<AgeRatingContentDescription> ContentDescriptions { get; set; }
        public long? Id { get; set; }
        public AgeRatingTitle? Rating { get; set; }
        public string RatingCoverUrl { get; set; }
        public string Synopsis { get; set; }
    }

    public enum AgeRatingCategory
    {
        ESRB = 1,
        PEGI = 2
    }

    public enum AgeRatingTitle
    {
        Three = 1,
        Seven = 2,
        Twelve = 3,
        Sixteen = 4,
        Eighteen = 5,
        RP = 6,
        EC = 7,
        E = 8,
        E10 = 9,
        T = 10,
        M = 11,
        AO = 12
    }
}