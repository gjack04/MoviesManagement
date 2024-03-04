namespace MoviesManagement.Models.New
{
    public class RoomProjectionModel
    {
        public int ProjectionId { get; set; }
        public int MovieId { get; set; }
        public int RoomId { get; set; }
        public DateTime Start { get; set; }
        public DateTime FreeBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
