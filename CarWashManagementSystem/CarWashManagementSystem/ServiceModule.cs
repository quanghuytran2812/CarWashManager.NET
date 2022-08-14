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
    public partial class ServiceModule : Form
    {
        SqlCommand cm = new SqlCommand();
        dbConnect dbcon = new dbConnect();
        Service service;
        string title = "Car Wash Management System";
        public ServiceModule(Service sec)
        {
            InitializeComponent();
            service = sec;
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text == "" || txtPrice.Text == "")
                {
                    MessageBox.Show("Please fill out the data completely", "Warning");
                    return;
                }
                if (MessageBox.Show("Are you sure you would like to register service?", "Service Registration", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("INSERT INTO tbService (name, price)VALUES (@name, @price)", dbcon.connect());

                    cm.Parameters.AddWithValue("@name", txtName.Text);
                    cm.Parameters.AddWithValue("@price", txtPrice.Text);

                    dbcon.open();
                    cm.ExecuteNonQuery();
                    dbcon.close();
                    MessageBox.Show("Service has been successfully registered!", title);
                    Clear();// to clear data field, after data inserted into the database
                    service.loadService();
                }
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
                if (txtName.Text == "" || txtPrice.Text == "")
                {
                    MessageBox.Show("Please fill out the data completely", "Warning");
                    return;
                }
                if (MessageBox.Show("Are you sure you would like to edit service?", "Service Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("UPDATE tbService  SET name=@name, price=@price WHERE id=@id", dbcon.connect());

                    cm.Parameters.AddWithValue("@id", lblSld.Text);
                    cm.Parameters.AddWithValue("@name", txtName.Text);
                    cm.Parameters.AddWithValue("@price", txtPrice.Text);

                    dbcon.open();
                    cm.ExecuteNonQuery();
                    dbcon.close();
                    MessageBox.Show("Service has been successfully edited!", title);
                    this.Dispose();
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

        #region method
        public void Clear()
        {
            txtName.Clear();
            txtPrice.Clear();

            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }
        #endregion method
    }
}
