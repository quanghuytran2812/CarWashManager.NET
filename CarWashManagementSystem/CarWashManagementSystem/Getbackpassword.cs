using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace CarWashManagementSystem
{
    public partial class Getbackpassword : Form
    {
        string randomcode;
        public static string to;
        public Getbackpassword()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }

        private void btnSendCode_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            randomcode = (rand.Next(999999)).ToString();

            MailMessage mess = new MailMessage();
            to = (txtEmail.Text).ToString();
            mess.To.Add(to);
            mess.From = new MailAddress("huy.tran.mcs@gmail.com");
            mess.Body = "The code for resetting your password is "+randomcode;
            mess.Subject = "Code To Reset Password";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential("huy.tran.mcs@gmail.com", "tgqcguonnovqkvhs");
            try
            {
                smtp.Send(mess);
                MessageBox.Show("Successfully submitted code","Email",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (randomcode == (txtEnterCode.Text).ToString())
            {
                to = txtEmail.Text;
                passwordretrieval rp = new passwordretrieval();
                this.Hide();
                rp.ShowDialog();
            }
            else
            {
                MessageBox.Show("Wrong Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEnterCode.Clear();
            }
        }
    }
}
