using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarWashManagementSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            loadGrossProfit();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            panelSlide.Height = btnDashboard.Height;
            panelSlide.Top = btnDashboard.Top;
            openChildForm(new dashboard());
        }

        private void btnEmployer_Click(object sender, EventArgs e)
        {
            panelSlide.Height = btnEmployer.Height;
            panelSlide.Top = btnEmployer.Top;
            openChildForm(new Employer());
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            panelSlide.Height = btnCustomer.Height;
            panelSlide.Top = btnCustomer.Top;
            openChildForm(new Customer());
        }

        private void btnService_Click(object sender, EventArgs e)
        {
            panelSlide.Height = btnService.Height;
            panelSlide.Top = btnService.Top;
            openChildForm(new Service());
        }

        private void btnCash_Click(object sender, EventArgs e)
        {
            panelSlide.Height = btnCash.Height;
            panelSlide.Top = btnCash.Top;
            openChildForm(new Cash());
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            panelSlide.Height = btnReport.Height;
            panelSlide.Top = btnReport.Top;
            openChildForm(new Report());
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            panelSlide.Height = btnSetting.Height;
            panelSlide.Top = btnSetting.Top;
            openChildForm(new Setting());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            panelSlide.Height = btnLogout.Height;
            panelSlide.Top = btnLogout.Top;
            this.Dispose();
            Login login = new Login();
            login.ShowDialog();
        }

        #region
        // create a function any form to the panelChild on the mainform
        private Form activeForm = null;
        public void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChild.Controls.Add(childForm);
            panelChild.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        public void loadGrossProfit()
        {
            Report module = new Report();
            lblRevenue.Text = module.extractData("SELECT ISNULL(SUM(price),0) AS total FROM tbCash WHERE date >'" + DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd") + "'").ToString("#,##0.00");
            lblCostgood.Text = module.extractData("SELECT ISNULL(SUM(cost),0) AS Cost FROM tbCostofGood WHERE date >'" + DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd") + "'").ToString("#,##0.00");
            lblGrossProfit.Text = (double.Parse(lblRevenue.Text) - double.Parse(lblCostgood.Text)).ToString("#,##0.00");

            double revlast7 = module.extractData("SELECT ISNULL(SUM(price),0) AS total FROM tbCash WHERE date BETWEEN '" + DateTime.Now.AddDays(-14).ToString("yyyy-MM-dd") + "' AND '" + DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd") + "'");
            double coglast7 = module.extractData("SELECT ISNULL(SUM(cost),0) AS Cost FROM tbCostofGood WHERE date BETWEEN '" + DateTime.Now.AddDays(-14).ToString("yyyy-MM-dd") + "' AND '" + DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd") + "'");
            double gplast7 = revlast7 - coglast7;


            if (revlast7 > double.Parse(lblRevenue.Text))
                picRevenues.Image = Properties.Resources.down_25px;
            else
                picRevenues.Image = Properties.Resources.up_25px;

            if (gplast7 > double.Parse(lblGrossProfit.Text))
            {
                picGP.Image = Properties.Resources.down_25px;
                lblGrossProfit.ForeColor = Color.Red;
            }
            else
            {
                picGP.Image = Properties.Resources.up_25px;
                lblGrossProfit.ForeColor = Color.Green;
            }

        }
        #endregion
    }
}
