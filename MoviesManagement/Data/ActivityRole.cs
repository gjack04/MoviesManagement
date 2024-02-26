namespace MoviesManagement.Data
{
    public class ActivityRole
    {
        public int ActivityRoleId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; } = false;
        public List<ProjectionActivity>? Activities { get; set; }
    }
}
