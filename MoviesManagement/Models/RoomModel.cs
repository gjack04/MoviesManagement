using MoviesManagement.Data;
using MoviesManagement.Models.New;

namespace MoviesManagement.Models
{
    public class RoomModel
    {
        public int RoomId { get; set; }
        public string Name { get; set; }
        public int CleanTimeMins { get; set; }
        public bool IsDeleted { get; set; } = false;
        public List<RoomProjectionModel>? Projections { get; set; }
        public List<ItemModel>? Technologies { get; set; }
    }
}
