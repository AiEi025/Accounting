using Accounting.DataLayer.Context;
using Accounting.Utility;
using Accounting.ViewModels.Customers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Stimulsoft.Report.StiOptions;

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

            using (UnitOfWork db = new UnitOfWork())
            {
                List<ListCustomerViewModel> list = new List<ListCustomerViewModel>();

                list.Add(new ListCustomerViewModel() { CustomerID = 0, FullName = " انتخاب کنید" });
                list.AddRange(db.CustomerRepository.GetNameCustomers());
                comboBox1.DataSource = list;
                comboBox1.DisplayMember = "FullName";
                comboBox1.ValueMember = "CustomerID";
            }

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
                List<DataLayer.Accounting> result = new List<DataLayer.Accounting>();

                if ((int)comboBox1.SelectedValue != 0)
                {
                    int customerId = int.Parse(comboBox1.SelectedValue.ToString());
                    result.AddRange(db.AccountingRepository.Get(a => a.TypeID == TypeId && a.CustomerID == customerId));
                }

                else
                {
                    result.AddRange(db.AccountingRepository.Get(a => a.TypeID == TypeId));
                }

                DateTime? startdate;
                DateTime? enddate;
                if (txtFromDate.Text != "    /  /")
                {
                    startdate = Convert.ToDateTime(txtFromDate.Text);
                    startdate = DateConvertor.ToMiladi(startdate.Value);
                    result = result.Where(x => x.DateTilte >= startdate.Value).ToList();
                };

                if (txtToDate.Text != "    /  /")
                {
                    enddate = Convert.ToDateTime(txtToDate.Text);
                    enddate = DateConvertor.ToMiladi(enddate.Value);
                    result = result.Where(x => x.DateTilte <= enddate.Value).ToList();
                }



                //dataGridView1.DataSource = Account;
                dataGridView1.Rows.Clear();

                foreach (var accounting in result)
                {

                    string customerName = db.CustomerRepository.GetCustomerNameById(accounting.CustomerID);
                    dataGridView1.Rows.Add(accounting.ID, customerName, accounting.Amount, accounting.DateTilte.ToShamsi(), accounting.Description);
                }



            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Filter();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                if (dataGridView1.CurrentRow != null)
                {
                    int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    if (RtlMessageBox.Show("ایا از حذف اطمیتات دارید؟", "هشدار", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        db.AccountingRepository.Delete(id);
                        db.save();
                        Filter();
                    }
                }

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            if (dataGridView1.CurrentRow != null)
            {
                int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                frmNewAccounting frm = new frmNewAccounting();
                frm.AccountID = id;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Filter();
                }

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataTable dtPrint = new DataTable();
            dtPrint.Columns.Add("Customer");
            dtPrint.Columns.Add("Amount");
            dtPrint.Columns.Add("Date");
            dtPrint.Columns.Add("Description");
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                dtPrint.Rows.Add(
                    item.Cells[1].Value.ToString(),
                    item.Cells[2].Value.ToString(),
                    item.Cells[3].Value.ToString(),
                    item.Cells[4].Value.ToString()
                    );
            }
            //string reportPath = Path.Combine(Application.StartupPath, "Report.mrt");

            //stiPrint.Load(reportPath);
            //string reportPath = Path.Combine(Application.StartupPath, "Report.mrt.mrt");

            //if (!File.Exists(reportPath))
            //{
            //    MessageBox.Show($"Report file not found: {reportPath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            stiPrint.Load(Application.StartupPath + "/Report.mrt");
            stiPrint.RegData("DT",dtPrint);
            stiPrint.Show();
            //"C:\Users\a-ehsani\source\repos\Accounting\Main\Accounting.App\bin\Debug\Report.mrt.mrt"
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
         
        }
    }
}
