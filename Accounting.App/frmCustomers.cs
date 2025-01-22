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

namespace Accounting.App
{
    public partial class frmCustomers : Form
    {
        public frmCustomers()
        {
            
            InitializeComponent();
            BindGrid();
        }

        void BindGrid()
        {
            //dgvCustomers.AutoGenerateColumns = false;

            using (UnitOfWork db = new UnitOfWork())
            {
                //BindingSource bs = new BindingSource();
                //bs.DataSource = dgvCustomers.DataSource;
                dgvCustomers.DataSource = db.CustomerRepository.GetAllCustomers();
                //dgvCustomers.Columns[0].Visible = false;
                //dgvCustomers.Columns[3].Visible = false;
                //dgvCustomers.Columns[4].Visible = false;

                dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void frmCustomers_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void TxtFilter_TextChanged(object sender, EventArgs e)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                db.CustomerRepository.GetCustomersByFilter(TxtFilter.Text);
            }
        }
    }
}
