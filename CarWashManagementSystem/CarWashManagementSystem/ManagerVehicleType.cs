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
    public partial class ManagerVehicleType : Form
    {
        SqlCommand cm = new SqlCommand();
        dbConnect dbcon = new dbConnect();
        Setting setting;
        string title = "Car Wash Management System";

        public ManagerVehicleType(Setting sett)
        {
            InitializeComponent();
            setting = sett;
            cbClass.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                    if (txtName.Text == "")
                    {
                        MessageBox.Show("Please fill out the vehicle type name completely", "Warning");
                        return;
                    }
                    if (MessageBox.Show("Are you sure you would like to register vehicle type?", "Vehicle Type Registration", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cm = new SqlCommand("INSERT INTO tbVehicleType (name, class)VALUES (@name, @class)", dbcon.connect());

                        cm.Parameters.AddWithValue("@name", txtName.Text);
                        cm.Parameters.AddWithValue("@class", cbClass.Text);

                        dbcon.open();
                        cm.ExecuteNonQuery();
                        dbcon.close();
                        MessageBox.Show("Vehicle Type has been successfully registered!", title);
                        Clear();// to clear data field, after data inserted into the database
                        setting.loadVehicleType();
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
                if (txtName.Text == "")
                {
                    MessageBox.Show("Please fill out the vehicle type name completely", "Warning");
                    return;
                }
                else if (MessageBox.Show("Are you sure you would like to update vehicle type?", "Vehicle Type Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("UPDATE tbVehicleType SET name=@name, class=@class WHERE id=@id", dbcon.connect());

                    cm.Parameters.AddWithValue("@id", lblVld.Text);
                    cm.Parameters.AddWithValue("@name", txtName.Text);
                    cm.Parameters.AddWithValue("@class", cbClass.Text);

                    dbcon.open();
                    cm.ExecuteNonQuery();
                    dbcon.close();
                    MessageBox.Show("Vehicle Type has been successfully updated!", title);
                    Clear();// to clear data field, after data inserted into the database
                    setting.loadVehicleType();//reload the vehicle list after update the record
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
            cbClass.SelectedIndex = 0;
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }
        #endregion method
    }
}
