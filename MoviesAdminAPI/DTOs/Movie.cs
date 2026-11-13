namespace MoviesAdminAPI.DTOs
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int AudienceRatingId { get; set; }
        public int RuntimeMinutes { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }

        //public int GenreId { get; set; }
        public Genre Genre { get; set; } = null!;

        public AudienceRating AudienceRating { get; set; } = null!;
    }
}
