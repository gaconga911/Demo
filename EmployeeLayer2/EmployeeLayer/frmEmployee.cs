using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using EMDTO;
using EMBUS;

namespace EmployeeLayer
{
    public partial class frmEmployee : Form
    {
        public frmEmployee()
        {
            InitializeComponent();
        }
        private List<EmployeeDTO> GetEmployee()
        {
            string sql = "SELECT * FROM Employees";
            return new EmployeeBUS().GetEmployee(sql);
        }
        private void init()
        {
            dgvEmployee.DataSource = GetEmployee();
        }
        private void frmEmployee_Load(object sender, EventArgs e)
        {
            init();
        }

        private int Add()
        {
            int id, dept;
            string lastName, firstName;
            //lấy thông tin từ form
            id = int.Parse(txtID.Text.Trim());
            lastName = txtLastName.Text;
            firstName = txtFirstName.Text;
            dept = int.Parse(txtDept.Text.Trim());
            //1 đối tượng chứa các thông tin đã lấy
            EmployeeDTO emp = new EmployeeDTO(id, lastName, firstName, dept);
            //chuyển xuống BUS
            EmployeeBUS empBus = new EmployeeBUS();
            //và gọi hàm add
            return empBus.Add(emp);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add();
            init();
        }





    }
}
