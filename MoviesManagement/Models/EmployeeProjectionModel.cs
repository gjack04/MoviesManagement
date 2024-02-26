using Microsoft.EntityFrameworkCore;
using MoviesManagement.Data;
namespace MoviesManagement.Models
{
    [PrimaryKey(nameof(EmployeeId), nameof(ActivityRoleId), nameof(ProjectionId))]
    public class EmployeeProjectionModel
    {
        public int EmployeeId { get; set; }
        public int ActivityRoleId { get; set; }
        public int ProjectionId { get; set; }
        public string RoomName {  get; set; }
        public DateTime Start {  get; set; }
        public string Description { get; set; }
    }
}
