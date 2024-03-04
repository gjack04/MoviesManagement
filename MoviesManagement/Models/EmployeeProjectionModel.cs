using Microsoft.EntityFrameworkCore;
using MoviesManagement.Data;

namespace MoviesManagement.Models
{
    public class EmployeeProjectionModel
    {
        public int EmployeeId { get; set; }
        public int ActivityRoleId { get; set; }
        public int ProjectionId { get; set; }
        public string RoomName { get; set; }
        public DateTime Start { get; set; }
        public string Description { get; set; }
    }
}
