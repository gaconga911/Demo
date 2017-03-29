using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using EMDTO;


namespace EMDAO
{
    public class EmployeeDAO
    {
        public DataProvider dp; //đối tượng dp
        public EmployeeDAO()  //khởi tạo
        {
            dp = new DataProvider();
        }

        public List<EmployeeDTO> GetEmployee(string sql)
        {
            dp.Connect();
            try
            {
                List<EmployeeDTO> list = new List<EmployeeDTO>();
                int id, deptID;
                string lastName, firstName;
                SqlDataReader dr = dp.ExecuteData(sql);
                while (dr.Read())
                {
                    id = dr.GetInt32(0);
                    lastName = dr.GetString(1);
                    firstName = dr.GetString(2);
                    deptID = dr.GetInt32(3);
                    EmployeeDTO emp = new EmployeeDTO(id, lastName, firstName, deptID);
                    list.Add(emp);
                }
                dr.Close();
                return list;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                dp.DisConnect();
            }
            
        }

        public int Add(EmployeeDTO emp)
        {
            //list ds để chứa các thông tin từ emp(DTO) để truyền cho hàm ExecuteNonQuery
            List<SqlParameter> paras = new List<SqlParameter>();
            
            paras.Add(new SqlParameter("@ID", emp.ID));
            paras.Add(new SqlParameter("@LastName", emp.LastName));
            paras.Add(new SqlParameter("@FirstName", emp.FirstName));
            paras.Add(new SqlParameter("@DeptID", emp.DeptID));
            try
            {
                                        //Thêm Proc đã tạo ở SQL                            
                return dp.ExecuteNonQuery("ThemNV", System.Data.CommandType.StoredProcedure, paras);
            }
            catch (SqlException ex)
            {
                
                throw ex;
            }
        }
    }
}
