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
    public partial class Employer : Form
    {
        SqlCommand cm = new SqlCommand();
        dbConnect dbcon = new dbConnect();
        SqlDataReader dr;
        string title = "Car Wash Management System";
        public Employer()
        {
            InitializeComponent();
            loadEmployer();// to call this function, this form start
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EmployerModule module = new EmployerModule(this);
            module.btnUpdate.Enabled = false;//this is for save, not for update
            module.ShowDialog();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            loadEmployer();
        }

        private void dvgEmployer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dvgEmployer.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                //to send employer data to the employer module
                EmployerModule module = new EmployerModule(this);
                module.lblEld.Text = dvgEmployer.Rows[e.RowIndex].Cells[1].Value.ToString();
                module.txtName.Text = dvgEmployer.Rows[e.RowIndex].Cells[2].Value.ToString();
                module.txtPhone.Text = dvgEmployer.Rows[e.RowIndex].Cells[3].Value.ToString();
                module.txtAddress.Text = dvgEmployer.Rows[e.RowIndex].Cells[4].Value.ToString();
                module.dtDob.Text = dvgEmployer.Rows[e.RowIndex].Cells[5].Value.ToString();
                module.rdMale.Checked = dvgEmployer.Rows[e.RowIndex].Cells[6].Value.ToString()=="Male"?true:false;//like if condition
                module.cbRole.Text = dvgEmployer.Rows[e.RowIndex].Cells[7].Value.ToString();
                module.txtSalary.Text = dvgEmployer.Rows[e.RowIndex].Cells[8].Value.ToString();
                module.txtPassword.Text = dvgEmployer.Rows[e.RowIndex].Cells[9].Value.ToString();
                module.txtEmail.Text = dvgEmployer.Rows[e.RowIndex].Cells[10].Value.ToString();

                module.btnSave.Enabled = false;
                module.ShowDialog();
            }
            else if (colName == "Delete")//if you want to delete the record to click the delete icon on the datagridview
            {
                try
                {
                    if (MessageBox.Show("Are you sure you would like to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cm = new SqlCommand("DELETE FROM tbEmployer WHERE id LIKE '" + dvgEmployer.Rows[e.RowIndex].Cells[1].Value.ToString() + "'",dbcon.connect());
                        dbcon.open();
                        cm.ExecuteNonQuery();
                        dbcon.close();
                        MessageBox.Show("Employer data has been successfully removed!",title,MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message,title);
                }
            }
            loadEmployer();
        }

        #region method
        //query employer list data form the database to the datagridview
        public void loadEmployer()
        {
            try
            {
                int i = 0;//show number for employer list 
                dvgEmployer.Rows.Clear();
                cm = new SqlCommand("SELECT * FROM tbEmployer WHERE CONCAT(name,address,role) LIKE '%" + txtSearch.Text + "%'", dbcon.connect());
                dbcon.open();
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    //to add data to the datagridview from the database
                    i++;
                    dvgEmployer.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), DateTime.Parse(dr[4].ToString()).ToShortDateString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), dr[9].ToString());
                }
                dbcon.close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,title);
            }
        }
        #endregion method



    }
}
