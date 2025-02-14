using Accounting.DataLayer.Context;
using Accounting.DataLayer;
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
    public partial class frmLogin : Form
    {
        public bool IsEdit = false;
        private string Username;
        private string Password;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void Enter_Click(object sender, EventArgs e)

        {
            
            if (BaseValidator.IsFormValid(this.components))
            {
                using (UnitOfWork db = new UnitOfWork())
                {
                    if (IsEdit == true)
                    {
                        //    var Edit = db.LoginRepository.Get().First();
                        //    Edit.Password = txtPassword.Text;
                        //    Edit.UserName = txtUserName.Text;
                        //    db.LoginRepository.Update(Edit);
                        List<Login> login = new List<Login>();
                        login = db.LoginRepository.Get().ToList();

                        foreach (var r in login)
                        {
                            r.UserName = txtUserName.Text;
                            r.Password = txtPassword.Text;
                            db.LoginRepository.Update(r);
                        }

                        db.save();
                        Application.Restart();
                    }
                    else
                    {
                        if (db.LoginRepository.Get(x => x.UserName == txtUserName.Text && x.Password == txtPassword.Text).Any())
                        {
                            DialogResult = DialogResult.OK;
                        }
                        else
                        { RtlMessageBox.Show("اطلاعات وارد شده صحیح نمی باشد"); }
                    }


                }
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            if (IsEdit == true)
            {
                this.Text = "ذخیره تغییرات";
                Enter.Text = "ذخیره";
                using (UnitOfWork db = new UnitOfWork())
                {
                    List<Login> login = new List<Login>();
                    //login.Add(new Login { UserName = txtUserName.Text, Password = txtPassword.Text });
                    login = db.LoginRepository.Get().ToList();

                    foreach (var r in login)
                    {
                        txtPassword.Text = r.Password;
                        txtUserName.Text = r.UserName;
                    }

                    //var Edit = db.LoginRepository.Get().First();
                    //txtPassword.Text = Edit.Password;
                    //txtUserName.Text = Edit.UserName;
                }
            }
        }
    }
}
