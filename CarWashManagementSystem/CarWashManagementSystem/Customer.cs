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
    public partial class Customer : Form
    {
        SqlCommand cm = new SqlCommand();
        dbConnect dbcon = new dbConnect();
        SqlDataReader dr;
        string title = "Car Wash Management System";

        public Customer()
        {
            InitializeComponent();
            loadCustomer();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CustomerModule module = new CustomerModule(this);
            module.btnUpdate.Enabled = false;
            module.ShowDialog();
        }

        private void dvgEmployer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dvgCustomer.Columns[e.ColumnIndex].Name;
            if (colName == "EditCustomer")
            {
                //to send customer data to the employer module
                CustomerModule module = new CustomerModule(this);
                module.lblCld.Text = dvgCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
                module.txtName.Text = dvgCustomer.Rows[e.RowIndex].Cells[2].Value.ToString();
                module.txtPhone.Text = dvgCustomer.Rows[e.RowIndex].Cells[3].Value.ToString();
                module.txtCarNo.Text = dvgCustomer.Rows[e.RowIndex].Cells[4].Value.ToString();
                module.txtCarModel.Text = dvgCustomer.Rows[e.RowIndex].Cells[5].Value.ToString();
                module.vid = vehicleIdbyName(dvgCustomer.Rows[e.RowIndex].Cells[6].Value.ToString());
                module.txtAddress.Text = dvgCustomer.Rows[e.RowIndex].Cells[7].Value.ToString();
                module.udPoints.Text = dvgCustomer.Rows[e.RowIndex].Cells[8].Value.ToString();

                module.btnSave.Enabled = false;
                module.udPoints.Enabled = true;
                module.ShowDialog();
            }
            else if (colName == "DeleteCustomer")//if you want to delete the record to click the delete icon on the datagridview
            {
                try
                {
                    if (MessageBox.Show("Are you sure you would like to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cm = new SqlCommand("DELETE FROM tbCustomer WHERE id LIKE '" + dvgCustomer.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", dbcon.connect());
                        dbcon.open();
                        cm.ExecuteNonQuery();
                        dbcon.close();
                        MessageBox.Show("Customer data has been successfully removed!", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, title);
                }
            }
            loadCustomer();
        }

        #region method
        public void loadCustomer()
        {
            try
            {
                int i = 0;//show number for customer list 
                dvgCustomer.Rows.Clear();
                cm = new SqlCommand("SELECT C.id,C.name, phone, carno,carmodel,V.name,address,points FROM tbCustomer AS C INNER JOIN tbVehicleType AS V ON C.vid=V.id WHERE CONCAT(C.name,carno,carmodel,address) LIKE '%" + txtSearchCustomer.Text + "%'", dbcon.connect());
                dbcon.open();
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    //to add data to the datagridview from the database
                    i++;
                    dvgCustomer.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString());
                }
                dbcon.close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title);
            }
        }

        public int vehicleIdbyName(string str)
        {
            int i = 0;
            cm = new SqlCommand("SELECT id FROM tbVehicleType WHERE name LIKE '" + str + "'",dbcon.connect());
            dbcon.open();
            dr = cm.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                i = int.Parse(dr["id"].ToString());
            }
            dbcon.close();
            return i;
        }
        #endregion method

        private void txtSearchCustomer_TextChanged(object sender, EventArgs e)
        {
            loadCustomer();
        }
    }
}
