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
    public partial class CustomerModule : Form
    {
        SqlCommand cm = new SqlCommand();
        dbConnect dbcon = new dbConnect();
        Customer customer;
        public int vid = 0;
        string title = "Car Wash Management System";
        bool check = false;
        public CustomerModule(Customer cust)
        {
            InitializeComponent();
            customer = cust;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                checkField();
                if (check)
                {
                    if (MessageBox.Show("Are you sure you would like to register new Customer?", "Customer Registration", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cm = new SqlCommand("INSERT INTO tbCustomer(vid,name,phone,carno,carmodel,address,points)VALUES(@vid,@name,@phone,@carno,@carmodel,@address,@points)", dbcon.connect());

                        cm.Parameters.AddWithValue("@vid", cbVehicleType.SelectedValue);//to save id number of vehicle type
                        cm.Parameters.AddWithValue("@name", txtName.Text);
                        cm.Parameters.AddWithValue("@phone", txtPhone.Text);
                        cm.Parameters.AddWithValue("@carno", txtCarNo.Text);
                        cm.Parameters.AddWithValue("@carmodel", txtCarModel.Text);
                        cm.Parameters.AddWithValue("@address", txtAddress.Text);
                        cm.Parameters.AddWithValue("@points", udPoints.Text);

                        dbcon.open();
                        cm.ExecuteNonQuery();
                        dbcon.close();
                        MessageBox.Show("Customer has been successfully registered!", title);
                        check = false;                       
                        Clear();// to clear data field, after data inserted into the database                      
                    }
                }
                customer.loadCustomer();//refesh the customer after insert data in the table
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                checkField();
                if (check)
                {
                    if (MessageBox.Show("Are you sure you would like to register new Customer?", "Customer Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cm = new SqlCommand("UPDATE tbCustomer SET vid=@vid,name=@name,phone=@phone,carno=@carno,carmodel=@carmodel,address=@address,points=@points WHERE id=@id", dbcon.connect());

                        cm.Parameters.AddWithValue("@id", lblCld.Text);
                        cm.Parameters.AddWithValue("@vid", cbVehicleType.SelectedValue);//to save id number of vehicle type
                        cm.Parameters.AddWithValue("@name", txtName.Text);
                        cm.Parameters.AddWithValue("@phone", txtPhone.Text);
                        cm.Parameters.AddWithValue("@carno", txtCarNo.Text);
                        cm.Parameters.AddWithValue("@carmodel", txtCarModel.Text);
                        cm.Parameters.AddWithValue("@address", txtAddress.Text);
                        cm.Parameters.AddWithValue("@points", udPoints.Text);

                        dbcon.open();
                        cm.ExecuteNonQuery();
                        dbcon.close();
                        MessageBox.Show("Customer has been successfully edited!", title);   
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
        }

        private void CustomerModule_Load(object sender, EventArgs e)
        {
            //to add vehicle list in the combox 
            cbVehicleType.DataSource = vehicleType();
            cbVehicleType.DisplayMember = "name";
            cbVehicleType.ValueMember = "id";
            if (vid>0)
            {
                cbVehicleType.SelectedValue = vid;
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

        #region method
        //to create a function vehicle type
        public DataTable vehicleType()
        {
            cm = new SqlCommand("SELECT * FROM tbVehicleType",dbcon.connect());
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();

            adapter.SelectCommand = cm;
            adapter.Fill(dataTable);

            return dataTable;
        }

        //to create a function for data field
        public void Clear()
        {
            txtName.Clear();
            txtPhone.Clear();
            txtCarNo.Clear();
            txtCarModel.Clear();
            txtAddress.Clear();

            cbVehicleType.SelectedIndex = 0;
            udPoints.Value = 0;

            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        public void checkField()
        {
            if (txtName.Text == "" || txtPhone.Text == "" || txtAddress.Text == "" || txtCarModel.Text == "")
            {
                MessageBox.Show("Please fill out the data completely", "Warning");
                return;
            }
            check = true;
        }
        #endregion method

    }
}
