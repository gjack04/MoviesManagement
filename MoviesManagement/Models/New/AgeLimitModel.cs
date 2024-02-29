namespace MoviesManagement.Models.New
{
    public class AgeLimitModel
    {
        public int AgeLimitId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; } = false;
        public List<ItemModel>? MoviesItem { get; set; }
    }
}
