namespace MoviesManagement.Data
{
    public class Technology
    {
        public int TechnologyId { get; set; }
        public string Name { get; set; }
        public string TechnologyType { get; set; }
        public bool IsDeleted { get; set; } = false;
        public List<Room>? Rooms { get; set; }
        public List<Movie>? Movies { get; set; }
    }


    public class TechnologyJson
    {
        public string name { get; set; }
        public string type { get; set; }
    }

}
