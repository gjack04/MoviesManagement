using MoviesManagement.Data;

namespace MoviesManagement.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool IsDeleted { get; set; }
        public List<EmployeeProjectionModel>? EmployeeProjections { get; set; }
    }
}
