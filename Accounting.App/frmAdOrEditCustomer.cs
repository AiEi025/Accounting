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
        UnitOfWork db = new UnitOfWork();
        public int customerId = 0;
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
            //using (UnitOfWork qw = new UnitOfWork())
            //{
            
            if (customerId == 0)
            {
                this.Text = "افزودن شخص جدید";
            }
            else
            {
                this.Text = "ویرایش شخص";
                btnSave.Text = "ویرایش";
                var customer = db.CustomerRepository.GetCustomersById(customerId);
                TxtAddress.Text = customer.Address;
                TxtEmail.Text = customer.Email;
                TxtMobile.Text = customer.Mobile;
                TxtName.Text = customer.FullName;
                pictureBox1.ImageLocation = Application.StartupPath + "/Images/" + customer.CustomerImage;

            }
        
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (BaseValidator.IsFormValid(this.components))
            {



                //string location = pictureBox1.ImageLocation.ToString();   __Location of image 
                string imageName = Guid.NewGuid().ToString() + Path.GetExtension(pictureBox1.ImageLocation);
                string path = Application.StartupPath + "/images/";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                pictureBox1.Image.Save(path + imageName);
                Customers customers = new Customers()
                {
                    Address = TxtAddress.Text,
                    Email = TxtEmail.Text,
                    FullName = TxtName.Text,
                    Mobile = TxtMobile.Text,
                    CustomerImage = imageName
                };
                if (customerId == 0)
                {
                    db.CustomerRepository.InsertCustomer(customers);
                }
                else 
                {
                    customers.CustomerID = customerId;
                    db.CustomerRepository.UpdateCustomer(customers);
                }
                db.save();
                DialogResult = DialogResult.OK;

            }
        }
    }
}
