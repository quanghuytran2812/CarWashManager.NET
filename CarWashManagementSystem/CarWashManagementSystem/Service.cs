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
    public partial class Service : Form
    {
        SqlCommand cm = new SqlCommand();
        dbConnect dbcon = new dbConnect();
        SqlDataReader dr;
        string title = "Car Wash Management System";
        public Service()
        {
            InitializeComponent();
            loadService();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ServiceModule module = new ServiceModule(this);
            module.btnSave.Enabled = true;
            module.btnUpdate.Enabled = false;
            module.ShowDialog();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            loadService();
        }

        private void dvgService_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dvgService.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                //to send service data to the service module
                ServiceModule module = new ServiceModule(this);
                module.lblSld.Text = dvgService.Rows[e.RowIndex].Cells[1].Value.ToString();
                module.txtName.Text = dvgService.Rows[e.RowIndex].Cells[2].Value.ToString();
                module.txtPrice.Text = dvgService.Rows[e.RowIndex].Cells[3].Value.ToString();

                module.btnSave.Enabled = false;
                module.ShowDialog();
            }
            else if (colName == "Delete")//if you want to delete the record to click the delete icon on the datagridview
            {
                try
                {
                    if (MessageBox.Show("Are you sure you would like to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cm = new SqlCommand("DELETE FROM tbService WHERE id LIKE '" + dvgService.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", dbcon.connect());
                        dbcon.open();
                        cm.ExecuteNonQuery();
                        dbcon.close();
                        MessageBox.Show("Service data has been successfully removed!", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, title);
                }
            }
            loadService();
        }

        #region method
        public void loadService()
        {
            try
            {
                int i = 0;//show number for Service list 
                dvgService.Rows.Clear();
                cm = new SqlCommand("SELECT * FROM tbService WHERE name LIKE '%" + txtSearch.Text + "%'", dbcon.connect());
                dbcon.open();
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    //to add data to the datagridview from the database
                    i++;
                    dvgService.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
                }
                dbcon.close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title);
            }
        }
        #endregion method
    }
}
