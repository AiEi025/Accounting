using Accounting.DataLayer;
using Accounting.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Accounting.App
{
    public partial class frmCustomers : Form
    {
        Accounting_DBEntities1 ad = new Accounting_DBEntities1();
        public frmCustomers()
        {
            InitializeComponent();
            BindGrid();
        }

        void BindGrid()
        {
            dgvCustomers.AutoGenerateColumns = false;
            
            //using (UnitOfWork db = new UnitOfWork())

            using (UnitOfWork db = new UnitOfWork())
            {

                var connection = db.CustomerRepository.GetAllCustomers();
                 dgvCustomers.DataSource = connection;

                dgvCustomers.Columns[0].Visible = false;
                dgvCustomers.Columns[3].Visible = false;
                dgvCustomers.Columns[4].Visible = false;

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
                dgvCustomers.DataSource = db.CustomerRepository.GetCustomersByFilter(TxtFilter.Text);
            }
        }

        private void TxtFilter_Click(object sender, EventArgs e)
        {
            
        }

        private void btnRefreshCustomer_Click(object sender, EventArgs e)
        {
            TxtFilter.Text = "";
            BindGrid();
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow != null)
            {
                using (UnitOfWork db = new UnitOfWork())
                {
                    string name = dgvCustomers.CurrentRow.Cells[1].Value.ToString();
                    if (RtlMessageBox.Show($"ایا از حذف {name}مطمئن هستید", "توجه", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        int customerId = int.Parse(dgvCustomers.CurrentRow.Cells[0].Value.ToString());
                        db.CustomerRepository.DeleteCustomer(customerId);
                        db.save();
                    }
                    else
                    {
                        RtlMessageBox.Show("لطفا شخصی را انتخاب کنید");
                    }

                }
                
            }
            else
            {
                MessageBox.Show(text: "لطفا خطی را انتخاب کنید");
            }
            BindGrid();
        }

        private void btnAddNewCustomer_Click(object sender, EventArgs e)
        {
            frmAdOrEditCustomer frm = new frmAdOrEditCustomer();
            if (frm.ShowDialog() == DialogResult.OK )
            {
                BindGrid();
            }
        }

        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow != null)
            {
                int customerId = int.Parse(dgvCustomers.CurrentRow.Cells[0].Value.ToString());
                frmAdOrEditCustomer frm = new frmAdOrEditCustomer();
                frm.customerId = customerId;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    BindGrid(); 
                }
            }
        }
    }
}


