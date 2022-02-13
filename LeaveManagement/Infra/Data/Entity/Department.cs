using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Infra.Data.Entity
{
    public class Department
    {
        public int Index { get; set; }

        public string Name { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
