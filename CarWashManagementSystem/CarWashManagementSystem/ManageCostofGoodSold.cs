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
    public partial class ManageCostofGoodSold : Form
    {
        SqlCommand cm = new SqlCommand();
        dbConnect dbcon = new dbConnect();
        Setting setting;
        bool check = false;
        string title = "Car Wash Management System";

        public ManageCostofGoodSold(Setting sett)
        {
            InitializeComponent();
            setting = sett;
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
                    if (MessageBox.Show("Are you sure you would like to register cost of good sold?", "Cost of Good Sold Registration", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cm = new SqlCommand("INSERT INTO tbCostofGood (costname, cost, date)VALUES (@costname, @cost, @date)", dbcon.connect());

                        cm.Parameters.AddWithValue("@costname", txtCostName.Text);
                        cm.Parameters.AddWithValue("@cost", txtCost.Text);
                        cm.Parameters.AddWithValue("@date", dtCG.Value);

                        dbcon.open();
                        cm.ExecuteNonQuery();
                        dbcon.close();
                        MessageBox.Show("Cost of Good Sold has been successfully registered!", title);
                        Clear();// to clear data field, after data inserted into the database
                        setting.loadCostofGood();
                    }
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
                checkField();
                if (check)
                {
                    if (MessageBox.Show("Are you sure you would like to edit cost of good sold?", "Cost of Good Sold Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cm = new SqlCommand("UPDATE tbCostofGood SET costname=@costname, cost=@cost, date=@date WHERE id=@id", dbcon.connect());

                        cm.Parameters.AddWithValue("@id", lblCld.Text);
                        cm.Parameters.AddWithValue("@costname", txtCostName.Text);
                        cm.Parameters.AddWithValue("@cost", txtCost.Text);
                        cm.Parameters.AddWithValue("@date", dtCG.Value);

                        dbcon.open();
                        cm.ExecuteNonQuery();
                        dbcon.close();
                        MessageBox.Show("Cost of Good Sold has been successfully edited!", title);
                        Clear();// to clear data field, after data inserted into the database
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

        private void txtCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            // only allow digit number
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;//to ignore invalid syntax
            }
            // only allow one decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;//to ignore invalid syntax
            }
        }

        #region method

        public void checkField()
        {
            if (txtCostName.Text == "" || txtCost.Text == "")
            {
                MessageBox.Show("Please fill out the Cost of Good Sold completely", "Warning");
                return;
            }
            check = true;
        }

        public void Clear()
        {
            txtCostName.Clear();
            txtCost.Clear();
            dtCG.Value = DateTime.Now;

            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }
        #endregion method



        
    }
}
