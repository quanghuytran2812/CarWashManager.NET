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
    public partial class CashCustomer : Form
    {
        SqlCommand cm = new SqlCommand();
        dbConnect dbcon = new dbConnect();
        SqlDataReader dr;
        string title = "Car Wash Management System";
        Cash cash;
        public CashCustomer(Cash ca)
        {
            InitializeComponent();
            loadCustomer();
            cash = ca;
        }

        #region method
        public void loadCustomer()
        {
            try
            {
                int i = 0;//show number for customer list 
                dvgCustomer.Rows.Clear();
                cm = new SqlCommand("SELECT * FROM tbCustomer WHERE CONCAT(name,phone,address) LIKE '%" + txtSearch.Text + "%'", dbcon.connect());
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
        #endregion mothod

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            loadCustomer();
        }

        private void dvgCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dvgCustomer.Columns[e.ColumnIndex].Name;
            if (colName == "Select")
            {
                cash.customerId = int.Parse(dvgCustomer.Rows[e.RowIndex].Cells[1].Value.ToString());
                cash.vehicleTypeId = int.Parse(dvgCustomer.Rows[e.RowIndex].Cells[2].Value.ToString());
            }
            else return;
            this.Dispose();
            cash.panelCash.Height = 1;
        }
    }
}
