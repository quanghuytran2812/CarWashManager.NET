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
    public partial class passwordretrieval : Form
    {
        SqlCommand cm = new SqlCommand();
        dbConnect dbcon = new dbConnect();
        public passwordretrieval()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Getbackpassword getpass = new Getbackpassword();
            this.Hide();
            getpass.ShowDialog();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtNewPass.Text == txtConfirmPass.Text)
            {
                cm = new SqlCommand("UPDATE tbEmployer SET password=@password WHERE email=@email", dbcon.connect());
                cm.Parameters.AddWithValue("@password", txtNewPass.Text);
                cm.Parameters.AddWithValue("@email", Getbackpassword.to);

                dbcon.open();
                cm.ExecuteNonQuery();
                dbcon.close();
                MessageBox.Show("Your Password has been successfully Changed");
                this.Dispose();
                Login login = new Login();
                login.ShowDialog();
            }
            else
            {
                MessageBox.Show("Two passwords are incompatible", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPass.Clear();
            }

        }

        private void showPass_CheckedChanged(object sender, EventArgs e)
        {
            if (showPass.Checked)
            {
                txtNewPass.UseSystemPasswordChar = false;
                txtConfirmPass.UseSystemPasswordChar = false;
            }
            else
            {
                txtNewPass.UseSystemPasswordChar = true;
                txtConfirmPass.UseSystemPasswordChar = true;
            }
        }

        private void btnloses_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


    }
}
