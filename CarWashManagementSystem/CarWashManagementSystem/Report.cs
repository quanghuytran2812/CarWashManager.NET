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
    public partial class Report : Form
    {
        SqlCommand cm = new SqlCommand();
        dbConnect dbcon = new dbConnect();
        SqlDataReader dr;
        string title = "Car Wash Management System";
        public Report()
        {
            InitializeComponent();
            loadTopSelling();
            loadRevenues();
            loadCostofGood();
            loadGrossProfit();
        }

        #region TopSelling

        private void dtFromSelling_ValueChanged(object sender, EventArgs e)
        {
            loadTopSelling();
        }

        private void dtToSelling_ValueChanged(object sender, EventArgs e)
        {
            loadTopSelling();
        }

        //to load Top Selling
        public void loadTopSelling()
        {
            try
            {
                int i = 0;
                dvgTopSelling.Rows.Clear();
                cm = new SqlCommand("SELECT TOP 10 se.name,count(ca.sid) AS qty,ISNULL(SUM(ca.price),0) AS total FROM tbCash AS ca JOIN tbService AS se ON ca.sid=se.id WHERE ca.date BETWEEN '"+ dtFromSelling.Value.ToString("yyyy-MM-dd") + "' AND '" + dtToSelling.Value.ToString("yyyy-MM-dd") + "' AND status LIKE 'SOLD'"+
                                    "GROUP BY se.name ORDER BY qty DESC",dbcon.connect());
                dbcon.open();
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    dvgTopSelling.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
                }
                dr.Close();
                dbcon.close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title);
            }
        }
        #endregion TopSelling

        #region Revenues

        private void dtFromRevenues_ValueChanged(object sender, EventArgs e)
        {
            loadRevenues();
        }

        private void dtToRevenues_ValueChanged(object sender, EventArgs e)
        {
            loadRevenues();
        }

        public void loadRevenues()
        {
            try
            {
                int i = 0;
                dvgRevenues.Rows.Clear();
                double total = 0;
                cm = new SqlCommand("SELECT date, ISNULL(SUM(price),0) AS total FROM tbCash WHERE date BETWEEN '" + dtFromRevenues.Value.ToString("yyyy-MM-dd") + "' AND '" + dtToRevenues.Value.ToString("yyyy-MM-dd") + "'"+
                                    "AND status LIKE 'SOLD' GROUP BY date", dbcon.connect());
                dbcon.open();
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    dvgRevenues.Rows.Add(i, DateTime.Parse(dr[0].ToString()).ToShortDateString(), dr[1].ToString());
                    total += double.Parse(dr[1].ToString());
                }
                lblRevenues.Text = total.ToString("#,##0.00");
                dr.Close();
                dbcon.close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title);
            }
        }

        #endregion Revenues

        #region COG   

        private void dtFromCOG_ValueChanged(object sender, EventArgs e)
        {
            loadCostofGood();
        }

        private void dtToCOG_ValueChanged(object sender, EventArgs e)
        {
            loadCostofGood();
        }

        public void loadCostofGood()
        {
            try
            {
                int i = 0;//show number for cost of good sold list 
                dvgCOG.Rows.Clear();
                double total = 0;
                cm = new SqlCommand("SELECT costname,cost,date FROM tbCostofGood WHERE date BETWEEN '" + dtFromCOG.Value.ToString("yyyy-MM-dd") + "' AND '" + dtToCOG.Value.ToString("yyyy-MM-dd") + "'", dbcon.connect());
                dbcon.open();
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    //to add data to the datagridview from the database
                    i++;
                    dvgCOG.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), DateTime.Parse(dr[2].ToString()).ToShortDateString());
                    total += double.Parse(dr[1].ToString());
                }
                lblCostOG.Text = total.ToString("#,##0.00");
                dr.Close();
                dbcon.close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title);
            }
        }
        #endregion COG

        #region GrossProfit

        private void dtFromGP_ValueChanged(object sender, EventArgs e)
        {
            loadGrossProfit();
        }

        private void dtToGP_ValueChanged(object sender, EventArgs e)
        {
            loadGrossProfit();
        }

        public void loadGrossProfit()
        {
            txtrevenues.Text = extractData("SELECT ISNULL(SUM(price),0) AS total FROM tbCash WHERE date BETWEEN '" + dtFromGP.Value.ToString("yyyy-MM-dd") + "' AND '" + dtToGP.Value.ToString("yyyy-MM-dd") + "'").ToString("#,##0.00");
            txtCOG.Text = extractData("SELECT ISNULL(SUM(cost),0) AS Cost FROM tbCostofGood WHERE date BETWEEN '" + dtFromGP.Value.ToString("yyyy-MM-dd") + "' AND '" + dtToGP.Value.ToString("yyyy-MM-dd") + "'").ToString("#,##0.00");
            txtGP.Text = (double.Parse(txtrevenues.Text) - double.Parse(txtCOG.Text)).ToString("#,##0.00");
            if ((double.Parse(txtGP.Text)) < 0)
                txtGP.ForeColor = Color.Red;
            else
                txtGP.ForeColor = Color.Green;
        }
        //now to create a function to extract data from database
        public double extractData(string sql)
        {
            dbcon.open();
            cm = new SqlCommand(sql, dbcon.connect());
            double data = double.Parse(cm.ExecuteScalar().ToString());
            dbcon.close();
            return data;
        }
        #endregion GrossProfit
    }
}
