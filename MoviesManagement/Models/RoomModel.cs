using MoviesManagement.Data;

namespace MoviesManagement.Models
{
    public class RoomModel
    {
        public int RoomId { get; set; }
        public string Name { get; set; }
        public int CleanTimeMins { get; set; }
        public bool IsDeleted { get; set; } = false;
        public List<ProjectionModel>? Projections { get; set; }
        public List<Technology>? Technologies { get; set; }
    }
}
