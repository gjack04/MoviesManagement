namespace MoviesManagement.Data
{
    public class Room
    {
        public int RoomId { get; set; }
        public string Name { get; set; }
        public int CleanTimeMins { get; set; }
        public bool IsDeleted { get; set; } = false;
        public List<Projection>? Projections { get; set; }
        public List<Technology>? Technologies { get; set; }
    }
}
