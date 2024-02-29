namespace MoviesManagement.Models
{
    public class TechnologyRoomModel
    {
        public int RoomId { get; set; }
        public string Name { get; set; }
        public int CleanTimeMins { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
