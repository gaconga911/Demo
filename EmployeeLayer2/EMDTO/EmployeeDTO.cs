using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMDTO
{
    public class EmployeeDTO
    {
        public int ID { get; set; }
        public int DeptID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public EmployeeDTO(int id, string lastName, string firstName, int deptID)
        {
            ID = id;
            LastName = lastName;
            FirstName = firstName;
            DeptID = deptID;
        }
    }
}
