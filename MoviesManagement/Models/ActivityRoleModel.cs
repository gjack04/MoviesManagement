using Microsoft.Identity.Client;
using MoviesManagement.Data;

namespace MoviesManagement.Models
{
    public class ActivityRoleModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public List<ActivityProjectionModel>? Activities { get; set; }
    }
}
