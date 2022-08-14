﻿using System;
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
    public partial class Cash : Form
    {
        SqlCommand cm = new SqlCommand();
        dbConnect dbcon = new dbConnect();
        SqlDataReader dr;
        string title = "Car Wash Management System";
        public int customerId = 0, vehicleTypeId = 0;
        public Cash()
        {
            InitializeComponent();
            getTransno();
            loadCash();
        }
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            openChildForm(new CashCustomer(this));
            btnAddService.Enabled = true;
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            openChildForm(new CashService(this));
            btnAddCustomer.Enabled = false;
        }

        private void btnCash_Click(object sender, EventArgs e)
        {
            SettlePayment module = new SettlePayment(this);
            module.txtSale.Text = lbltotal.Text;
            module.ShowDialog();
        }

        #region method
        private Form activeForm = null;
        public void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelCash.Height = 150;
            panelCash.Controls.Add(childForm);
            panelCash.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        //create a function for transation generator denpend on date
        public void getTransno()
        {
            try
            {
                string sdate = DateTime.Now.ToString("yyyyMMdd");
                int count;
                string transno;

                dbcon.open();
                cm = new SqlCommand("SELECT TOP 1 transno FROM tbCash WHERE transno LIKE '"+sdate+"%' ORDER BY id DESC",dbcon.connect());
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    transno = dr[0].ToString();
                    count = int.Parse(transno.Substring(8, 4));
                    lblTransno.Text = sdate + (count + 1);
                }
                else
                {
                    transno = sdate + "1001";
                    lblTransno.Text = transno;
                }
                dbcon.close();
                dr.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,title);
            }
        }

        private void dvgCash_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dvgCash.Columns[e.ColumnIndex].Name;
            if (colName == "Delete")//if you want to delete the record to click the delete icon on the datagridview
            {
                try
                {
                    if (MessageBox.Show("Are you sure you would like to cancel this services?", "Cancel Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cm = new SqlCommand("DELETE FROM tbCash WHERE id LIKE '" + dvgCash.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", dbcon.connect());
                        dbcon.open();
                        cm.ExecuteNonQuery();
                        dbcon.close();
                        MessageBox.Show("Services has been successfully canceled!", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, title);
                }
            }
            loadCash();
        }

        public void loadCash()
        {
            int i = 0;
            double total = 0;
            double price = 0;
            dvgCash.Rows.Clear();
            cm = new SqlCommand("SELECT ca.id,ca.transno,cu.name,cu.carno,cu.carmodel,v.name,v.class,s.name,ca.price,ca.date FROM tbCash AS Ca LEFT JOIN tbCustomer AS Cu ON CA.cid=Cu.id LEFT JOIN tbService AS s ON CA.sid=s.id LEFT JOIN tbVehicleType AS v ON Ca.vid=v.id WHERE status LIKE 'Pending' AND Ca.transno='"+lblTransno.Text+"'", dbcon.connect());
            dbcon.open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                price = int.Parse(dr[6].ToString()) * double.Parse(dr[8].ToString());
                dvgCash.Rows.Add(i,dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), price, dr[9].ToString());
                total +=price;              
            }
            dr.Close();
            dbcon.close();
            lbltotal.Text = total.ToString("#,##0.00");

        }
        #endregion method
    }
}
