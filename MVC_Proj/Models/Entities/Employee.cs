using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Proj.Models.Entities
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeePosition { get;set;}
        public string EmployeeDepartment { get; set; }
    }
}
