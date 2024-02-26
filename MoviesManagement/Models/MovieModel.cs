using System.ComponentModel.DataAnnotations;

namespace MoviesManagement.Models
{
    public class MovieModel
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        [RegularExpression("^(tt[0-9]{7})$")]
        public required string ImdbId { get; set; }
        public int AgeLimitId { get; set; }
        public string? AgeLimit { get; set; }
        public int DurationMins { get; set; }
        public bool IsDeleted { get; set; }
        public List<ItemModel>? Technologies { get; set; }
        public List<MovieProjectionModel>? Projections { get; set; }
    }
}
