using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using EMDTO;
using EMDAO;

namespace EMBUS
{
    public class EmployeeBUS
    {
        public List<EmployeeDTO> GetEmployee(string sql)
        {
            try
            {
                return new EmployeeDAO().GetEmployee(sql);
            }
            catch (SqlException ex)
            {
                
                throw ex;
            }
        }

        public int Add(EmployeeDTO emp)
        {
            if (emp.LastName == "" || emp.FirstName == "")
                return -2;
           
            try
            {
                //tạo đối tượng EmployeeDAO (lớp DAO) , gọi Add
                return (new EmployeeDAO().Add(emp));
            }
            catch (SqlException ex)
            {
                
                throw ex;
            }

        }
    }
}
