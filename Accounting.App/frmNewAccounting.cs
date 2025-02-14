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
using ValidationComponents;

namespace Accounting.App
{
    public partial class frmNewAccounting : Form
    {
        public int AccountID = 0;
        UnitOfWork db = new UnitOfWork();
        public frmNewAccounting()
        {
            InitializeComponent();
        }

        private void frmNewAccounting_Load(object sender, EventArgs e)
        {
            dgvCustomers.AutoGenerateColumns = false;
            dgvCustomers.DataSource = db.CustomerRepository.GetNameCustomers();

            if (AccountID != 0)
            {
                var account = db.AccountingRepository.GetById(AccountID);
                txtAmount.Text = account.Amount.ToString();
                txtDescription.Text = account.Description;
                textBox1.Text = db.CustomerRepository.GetCustomerNameById(account.CustomerID);
                if (account.TypeID == 1)
                {
                    rbRecive.Checked = true;
                }
                if (account.TypeID == 2)
                {
                    rbPay.Checked = true;
                }
                this.Text = "ویرایش";
                btnSave.Text = "ویرایش";
            }
        }

        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            dgvCustomers.AutoGenerateColumns = false;
            dgvCustomers.DataSource = db.CustomerRepository.GetCustomersByFilter(txtFilter.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (BaseValidator.IsFormValid(this.components))
            {
                if (rbPay.Checked || rbRecive.Checked)
                {
                    DataLayer.Accounting accounting = new DataLayer.Accounting()
                    {
                        Amount = int.Parse(txtAmount.Value.ToString()),
                        CustomerID = db.CustomerRepository.GetCustomerIdByName(textBox1.Text),
                        TypeID = (rbRecive.Checked) ? 1 : 2,//در اینجا ؟ برای شرط استفاده میشود
                        DateTilte = DateTime.Now,
                        Description = txtDescription.Text
                    };
                    if (AccountID == 0)
                    {
                        db.AccountingRepository.insert(accounting);
                    }
                    else
                    {
                        using (UnitOfWork db2 = new UnitOfWork())
                        {
                            accounting.ID = AccountID;
                            db2.AccountingRepository.Update(accounting);
                            db2.save();
                        }
                           
                    }
                    db.save();
                    DialogResult = DialogResult.OK;
                }
                else
                {

                }

            }
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dgvCustomers.CurrentRow.Cells[0].Value.ToString();
        }
    }
}
