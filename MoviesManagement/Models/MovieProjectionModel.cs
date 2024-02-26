namespace MoviesManagement.Models
{
    public class MovieProjectionModel
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string? RoomName { get; set; }
        public DateTime Start { get; set; }
        public DateTime FreeBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
