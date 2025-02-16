using Accounting.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accounting.Utility;
using Accounting.ViewModels.Accounting;
using Accounting.Business;

namespace Accounting.App
{
    public partial class Form1 : Form
    {
        //UnitOfWork db = new UnitOfWork();   
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            this.Hide();

            frmLogin frm = new frmLogin();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.Show();
                lbldatetime.Text = DateTime.Now.ToShamsi();
                //lbltime.Text = DateTime.Now.ToShortTimeString();
                lbltime.Text = DateTime.Now.ToString("HH:MM:ss");
                 Report();
            }
            else
            { 
            Application.Exit();
            }

            
        }
        void Report()
        {
            ReportViewModel report = Account.ReportFormMain();
            lblRecive.Text = report.Recive.ToString("#,0");
            lblPay.Text = report.Pay.ToString("#,0");
            lblAccountBalance.Text = report.AccountBalance.ToString("#,0");
        }



        private void btnCustomer_Click(object sender, EventArgs e)
        {
            frmCustomers frm = new frmCustomers();
            frm.ShowDialog();
        }

        private void btnNewAccounting_Click(object sender, EventArgs e)
        {
            frmNewAccounting frm = new frmNewAccounting();
            frm.ShowDialog();

        }

        private void btnReportPay_Click(object sender, EventArgs e)
        {
            frmReport frm = new frmReport();
            frm.TypeId = 2;
            frm.ShowDialog();
        }

        private void btnRecive_Click(object sender, EventArgs e)
        {
            frmReport frm = new frmReport();
            frm.TypeId = 1;
            frm.ShowDialog();
        }

        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    lbltime.Text = DateTime.Now.ToString("HH:MM:ss");
        //}

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            frm.IsEdit = true;
            frm.Show();

        }
    }
}
