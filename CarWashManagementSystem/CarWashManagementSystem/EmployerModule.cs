using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CarWashManagementSystem
{
    public partial class EmployerModule : Form
    {
        SqlCommand cm = new SqlCommand();
        dbConnect dbcon = new dbConnect();
        string title = "Car Wash Management System";
        bool check = false;
        Employer employer;
        public EmployerModule(Employer emp)
        {
            InitializeComponent();
            employer = emp;
            cbRole.SelectedIndex = 3; 
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        //insert new employer
        private void btnSave_Click(object sender, EventArgs e)
        {      
            try
            {
                checkField();
                if (check)
                {
                    if (MessageBox.Show("Are you sure you would like to register new employer?", "Employer Registration", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cm = new SqlCommand("INSERT INTO tbEmployer (name, phone, address,dob,gender,role,salary,password,email)VALUES (@name, @phone, @address, @dob, @gender, @role, @salary,@password,@email)", dbcon.connect());

                        cm.Parameters.AddWithValue("@name", txtName.Text);
                        cm.Parameters.AddWithValue("@phone", txtPhone.Text);
                        cm.Parameters.AddWithValue("@address", txtAddress.Text);
                        cm.Parameters.AddWithValue("@dob", dtDob.Value);
                        cm.Parameters.AddWithValue("@gender", rdMale.Checked ? "Male" : "Female");
                        cm.Parameters.AddWithValue("@role", cbRole.Text);
                        cm.Parameters.AddWithValue("@salary", txtSalary.Text);
                        cm.Parameters.AddWithValue("@password", txtPassword.Text);
                        cm.Parameters.AddWithValue("@email", txtEmail.Text);

                        dbcon.open();
                        cm.ExecuteNonQuery();
                        dbcon.close();
                        MessageBox.Show("Employer has been successfully registered!", title);
                        check = false;
                        employer.loadEmployer();//refesh the employer after insert data in the table
                        Clear();// to clear data field, after data inserted into the database                      
                    }
                }             
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,title);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                checkField();
                if (check)
                {
                    if (MessageBox.Show("Are you sure you would like to edit employer?", "Employer Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cm = new SqlCommand("UPDATE tbEmployer SET name=@name, phone=@phone, address=@address, dob=@dob, gender=@gender, role=@role, salary=@salary,password=@password, email=@email WHERE id=@id", dbcon.connect());

                        cm.Parameters.AddWithValue("@id", lblEld.Text);
                        cm.Parameters.AddWithValue("@name", txtName.Text);
                        cm.Parameters.AddWithValue("@phone", txtPhone.Text);
                        cm.Parameters.AddWithValue("@address", txtAddress.Text);
                        cm.Parameters.AddWithValue("@dob", dtDob.Value);
                        cm.Parameters.AddWithValue("@gender", rdMale.Checked ? "Male" : "Female");
                        cm.Parameters.AddWithValue("@role", cbRole.Text);
                        cm.Parameters.AddWithValue("@salary", txtSalary.Text);
                        cm.Parameters.AddWithValue("@password", txtPassword.Text);
                        cm.Parameters.AddWithValue("@email", txtEmail.Text);

                        dbcon.open();
                        cm.ExecuteNonQuery();
                        dbcon.close();
                        MessageBox.Show("Employer has been successfully edited!", title);
                        employer.loadEmployer();//refesh the employer after edit data in the table
                        this.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
        }

        private void txtSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            // only allow digit number
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // only allow digit number
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))//only allow digit number
            {
                e.Handled = true;//to ignore invalid syntax
            }
        }

        private void cbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbRole.Text == "Supervisor" || cbRole.Text == "Worker")
            {
                this.Height = 491 - 34;
                txtPassword.Clear();
                lblPass.Visible = false; 
                txtPassword.Visible = false;
            }
            else
            {
                lblPass.Visible = true;
                txtPassword.Visible = true;
                this.Height = 491;
            }
        }

        // to create a function for clear all field
        #region method   
        public void Clear(){
            txtAddress.Clear();
            txtName.Clear();
            txtPassword.Clear();
            txtPhone.Clear();
            txtSalary.Clear();
            txtEmail.Clear();

            dtDob.Value = DateTime.Now;
            cbRole.SelectedIndex = 3; //default is worker
        }

        //to check data field
        public void checkField()
        {
            if (txtName.Text == "" || txtPhone.Text == "" || txtAddress.Text == "" || txtSalary.Text == "" || txtEmail.Text == "")
            {
                MessageBox.Show("Please fill out the data completely", "Warning");
                return;
            }
            if (CheckAge(dtDob.Value) < 18)
            {
                MessageBox.Show("Employer must be at least 18 years old.", "Warning");
                return;
            }
            check = true;
        }
        //to check age and calculate for under 18
        public static int CheckAge(DateTime dateofBirth)
        {
            int age = DateTime.Now.Year - dateofBirth.Year;
            if (DateTime.Now.DayOfYear < dateofBirth.DayOfYear)
                age = age - 1;
            return age;
        }
        #endregion method

    }
}
