using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MoviesManagement.Data
{
    [PrimaryKey(nameof(EmployeeId), nameof(ActivityRoleId), nameof(ProjectionId))]
    public class ProjectionActivity
    {
        public int EmployeeId { get; set; }
        public int ActivityRoleId { get; set; }
        public int ProjectionId { get; set; }
        public Employee? Employee { get; set; }
        public Projection? Projection { get; set; }
        public ActivityRole? ActivityRole { get; set; }
    }
}
