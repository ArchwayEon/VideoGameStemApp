namespace VideoGameStemApp.Models
{
    public enum RatingCriteria
    {
        LoveIt, LikeIt, NotForMe
    }

    public class VideoGame
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Developer { get; set; } = string.Empty;
        public string Genres { get; set; } = string.Empty;
        public RatingCriteria Rating { get; set; }
    }
}
