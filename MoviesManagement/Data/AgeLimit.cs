namespace MoviesManagement.Data
{
    public class AgeLimit
    {
        public int AgeLimitId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; } = false;
        public List<Movie>? Movies { get; set; }
    }
}
