namespace MoviesManagement.Models
{
    public class TechnologyModel
    {
        public int TechnologyId { get; set; }
        public string Name { get; set; }
        public string TechnologyType { get; set; }
        public bool IsDeleted { get; set; } = false;
        public List<TechnologyRoomModel>? TechnologyRoom { get; set; }
    }
}
