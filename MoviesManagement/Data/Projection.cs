namespace MoviesManagement.Data
{
    public class Projection
    {
        public int ProjectionId { get; set; }
        public int MovieId { get; set; }
        public int RoomId { get; set; }
        public DateTime Start {  get; set; }
        public DateTime FreeBy { get; set; }
        public bool IsDeleted { get; set; } = false;
        public Movie? Movie { get; set; }
        public Room? Room { get; set; }
        public List<ProjectionActivity>? Activities { get; set; }
    }
}
