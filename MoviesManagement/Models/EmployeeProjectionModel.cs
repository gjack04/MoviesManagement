using Microsoft.EntityFrameworkCore;
using MoviesManagement.Data;

namespace MoviesManagement.Models
{
    public class EmployeeProjectionModel
    {
        public int ActivityRoleId { get; set; }
        public int ProjectionId { get; set; }
        public ItemModel ActivityRole { get; set; }
        public ItemModel Projection { get; set; }
    }
}
