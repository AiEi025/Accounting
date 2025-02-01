using Accounting.DataLayer;
using Accounting.DataLayer.Context;
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
using ValidationComponents;

namespace Accounting.App
{
    public partial class frmAdOrEditCustomer : Form
    {
        public frmAdOrEditCustomer()
        {
            InitializeComponent();
        }

        private void btnSelectPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                //pictureBox1.Image
                pictureBox1.ImageLocation = openfile.FileName;
                

            }
            
        }

        private void frmAdOrEditCustomer_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UnitOfWork db = new UnitOfWork();   
            if (BaseValidator.IsFormValid(this.components))
            {
               
                string location = pictureBox1.ImageLocation.ToString();
                string imageName = Guid.NewGuid().ToString() + Path.GetExtension(location);
                Customers customers = new Customers()
                {
                    Address = TxtAddress.Text,
                    Email = TxtEmail.Text,
                    FullName = TxtName.Text,
                    Mobile = TxtMobile.Text,
                    CustomerImage = "NoPhoto.jpg"
                };
                db.CustomerRepository.InsertCustomer(customers);
                db.save();
                DialogResult = DialogResult.OK;
            }
        }
    }
}
