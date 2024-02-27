using Microsoft.EntityFrameworkCore;
using MoviesManagement.Data;
using System.Globalization;
namespace MoviesManagement.Models
{
    [PrimaryKey(nameof(EmployeeId), nameof(ActivityRoleId), nameof(ProjectionId))]
    public class ActivityProjectionModel
    {
        public int ProjectionId { get; set; }
        public int ActivityRoleId { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public string ActivityRoleDescription { get; set;}
    }
}
