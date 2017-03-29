using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using EMDTO;
namespace EMDAO
{
	// sua 
    public class DataProvider
    {
        string cnstr = "";
        SqlConnection cn;
        public DataProvider()
        {
            cnstr = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
            cn = new SqlConnection(cnstr);
            Connect();
        }

        public void Connect()
        {

            try
            {
                if (cn != null && cn.State != ConnectionState.Open)
                {
                    cn.Open();
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public void DisConnect()
        {
            if (cn != null && cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
        }

        public SqlDataReader ExecuteData(string sql)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sql, cn);
                return cmd.ExecuteReader();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public int ExecuteNonQuery(string sql, CommandType type, List<SqlParameter> paras)
        {
         
           // tao đối tượng SQLCommand  
            SqlCommand cmd = new SqlCommand(sql,cn);
            cmd.CommandType =type;

            try
            {
                if (paras != null)
                {
                    foreach (SqlParameter par in paras)
                    {   
                        //lấy lại từ list paras truyền vào thuộc tính Parameters các thông tin 
                        cmd.Parameters.Add(par);
                    }
                }
                
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                //cần ngăt sau khi thêm, Phi kết nối
                DisConnect();
            }
        }
    }
}
