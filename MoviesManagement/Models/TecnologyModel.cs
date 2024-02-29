namespace MoviesManagement.Models
{
    public class TecnologyModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TecnologyType { get; set; }
        public bool IsDeleted { get; set; }
        public List<RoomModel>? Rooms { get; set; }
    }
}
