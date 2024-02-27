using Microsoft.Identity.Client;

namespace MoviesManagement.Models
{
    public class ActivityRoleModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public List<EmployeeModel> Employees { get; set; }
    }
}
