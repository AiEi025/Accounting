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
    public partial class frmReport : Form
    {
        public int TypeId = 0;
        public frmReport()
        {
            InitializeComponent();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (TypeId == 2)
            {
                this.Text = "گزارش پرداختی ها";
            }
            else
            {
                this.Text = "گزارش دریافتی ها";
            }

        }

        private void btnfilter_Click(object sender, EventArgs e)
        {
            
            Filter();
        }

        void Filter()
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                var Account = db.AccountingRepository.Get(x => x.TypeID == TypeId);
                dataGridView1.DataSource = Account;

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
