using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarWashManagementSystem
{
    public partial class Login : Form
    {
        SqlCommand cm = new SqlCommand();
        dbConnect dbcon = new dbConnect();
        SqlDataReader dr;
        string title = "Car Wash Management System";
        public Login()
        {
            InitializeComponent();
            loadComany();
        }

        public void loadComany()
        {
            try
            {
                dbcon.open();
                cm = new SqlCommand("SELECT * FROM tbCompany", dbcon.connect());
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    lblName.Text = dr["name"].ToString();
                    lblAddress.Text = dr["address"].ToString();
                }
                dr.Close();
                dbcon.close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtPass.Clear();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                cm = new SqlCommand("SELECT name FROM tbEmployer WHERE name='" + txtName.Text + "' AND password='"+txtPass.Text+"'", dbcon.connect());
                dbcon.open();
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    MessageBox.Show("WELCOME " +dr[0].ToString()+ "","ACCESS GRANTED",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.Hide();
                    MainForm main = new MainForm();
                    main.ShowDialog();
                }
                else
                {
                    MessageBox.Show("INVAILD USERNAME or PASSWORD", "DENIED GRANTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                dr.Close();
                dbcon.close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,title);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtPass.UseSystemPasswordChar = false;
            }
            else
            {
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void lblForgetPass_Click(object sender, EventArgs e)
        {
            Getbackpassword getpass = new Getbackpassword();
            this.Hide();
            getpass.ShowDialog();
        }

    }
}
