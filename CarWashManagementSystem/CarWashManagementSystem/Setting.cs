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
    public partial class Setting : Form
    {
        SqlCommand cm = new SqlCommand();
        dbConnect dbcon = new dbConnect();
        SqlDataReader dr;
        bool hasdetail = false;
        string title = "Car Wash Management System";
        public Setting()
        {
            InitializeComponent();
            loadVehicleType();
            loadCostofGood();
            loadComany();
        }

        #region VehicleType
        private void txtSearchVT_TextChanged(object sender, EventArgs e)
        {
            loadVehicleType();
        }

        private void btnAddVT_Click(object sender, EventArgs e)
        {
            ManagerVehicleType module = new ManagerVehicleType(this);
            module.btnUpdate.Enabled = false;
            module.ShowDialog();
        }

        private void dvgVehicleType_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dvgVehicleType.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                //to send Vehicle data to the Vehicle module
                ManagerVehicleType module = new ManagerVehicleType(this);
                module.lblVld.Text = dvgVehicleType.Rows[e.RowIndex].Cells[1].Value.ToString();
                module.txtName.Text = dvgVehicleType.Rows[e.RowIndex].Cells[2].Value.ToString();
                module.cbClass.Text = dvgVehicleType.Rows[e.RowIndex].Cells[3].Value.ToString();

                module.btnSave.Enabled = false;
                module.ShowDialog();
            }
            else if (colName == "Delete")//if you want to delete the record to click the delete icon on the datagridview
            {
                try
                {
                    if (MessageBox.Show("Are you sure you would like to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cm = new SqlCommand("DELETE FROM tbVehicleType WHERE id LIKE '" + dvgVehicleType.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", dbcon.connect());
                        dbcon.open();
                        cm.ExecuteNonQuery();
                        dbcon.close();
                        MessageBox.Show("Vehicle Type data has been successfully removed!", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message,title);
                }
            }
            loadVehicleType();
        }

        public void loadVehicleType()
        {
            try
            {
                int i = 0;//show number for Vehicle Type list 
                dvgVehicleType.Rows.Clear();
                cm = new SqlCommand("SELECT * FROM tbVehicleType WHERE CONCAT(name,class) LIKE '%" + txtSearchVT.Text + "%'", dbcon.connect());
                dbcon.open();
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    //to add data to the datagridview from the database
                    i++;
                    dvgVehicleType.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
                }
                dbcon.close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title);
            }
        }
        #endregion VehicleType

        #region CostofGoodSold
        private void btnAddCostofGood_Click_1(object sender, EventArgs e)
        {
            ManageCostofGoodSold module = new ManageCostofGoodSold(this);
            module.btnUpdate.Enabled = false;
            module.ShowDialog();
        }

        private void txtSearchCostG_TextChanged_1(object sender, EventArgs e)
        {
            loadCostofGood();
        }

        private void dvgCostofGoodSold_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dvgCostofGoodSold.Columns[e.ColumnIndex].Name;
            if (colName == "EditCofG")
            {
                //to send cost of good sold data to the cost of good sold module
                ManageCostofGoodSold module = new ManageCostofGoodSold(this);
                module.lblCld.Text = dvgCostofGoodSold.Rows[e.RowIndex].Cells[1].Value.ToString();
                module.txtCostName.Text = dvgCostofGoodSold.Rows[e.RowIndex].Cells[2].Value.ToString();
                module.txtCost.Text = dvgCostofGoodSold.Rows[e.RowIndex].Cells[3].Value.ToString();
                module.dtCG.Text = dvgCostofGoodSold.Rows[e.RowIndex].Cells[4].Value.ToString();

                module.btnSave.Enabled = false;
                module.ShowDialog();
            }
            else if (colName == "DeleteCofG")//if you want to delete the record to click the delete icon on the datagridview
            {
                try
                {
                    if (MessageBox.Show("Are you sure you would like to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cm = new SqlCommand("DELETE FROM tbCostofGood WHERE id LIKE '" + dvgCostofGoodSold.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", dbcon.connect());
                        dbcon.open();
                        cm.ExecuteNonQuery();
                        dbcon.close();
                        MessageBox.Show("Cost of Good Sold data has been successfully removed!", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, title);
                }
            }
            loadCostofGood();
        }

        public void loadCostofGood()
        {
            try
            {
                int i = 0;//show number for cost of good sold list 
                dvgCostofGoodSold.Rows.Clear();
                cm = new SqlCommand("SELECT * FROM tbCostofGood WHERE CONCAT(costname, cost, date) LIKE '%" + txtSearchCostG.Text + "%'", dbcon.connect());
                dbcon.open();
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    //to add data to the datagridview from the database
                    i++;
                    dvgCostofGoodSold.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), DateTime.Parse(dr[3].ToString()).ToShortDateString());
                }
                dbcon.close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title);
            }
        }
        #endregion CostofGoodSold

        #region Company Detail
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
                    hasdetail = true;
                    txtComName.Text = dr["name"].ToString();
                    txtComAddress.Text = dr["address"].ToString();
                }
                else
                {
                    txtComName.Clear();
                    txtComAddress.Clear();
                }
                dr.Close();
                dbcon.close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title);
            }           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you intend to save your company's information?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (hasdetail)//already have data and update data
                    {
                        dbcon.executeQuery("UPDATE tbCompany SET name='" + txtComName.Text + "',address='" + txtComAddress.Text + "'");
                    }
                    else//no data and add 1 new data
                    {
                        dbcon.executeQuery("INSERT INTO tbCompany (name,address) VALUES ('" + txtComName.Text + "','" + txtComAddress.Text + "')");
                    }
                    MessageBox.Show("Company detail has been successfully saved!","Save Record",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtComName.Clear();
            txtComAddress.Clear();
        }
        #endregion Company Detail


    }
}
