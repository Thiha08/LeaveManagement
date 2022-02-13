using System;

namespace LeaveManagement.Infra.Data.Entity
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime JoinedDate { get; set; }

        public int? CurrentDepartmentId { get; set; }

        public Department Department { get; set; } 

    }
}
