namespace Accounting.App
{
    partial class frmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Enter = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.requiredFieldValidator1 = new ValidationComponents.RequiredFieldValidator(this.components);
            this.requiredFieldValidator2 = new ValidationComponents.RequiredFieldValidator(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Enter);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtUserName);
            this.groupBox1.Controls.Add(this.lblUserName);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(422, 188);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ورود به برنامه";
            // 
            // Enter
            // 
            this.Enter.Cursor = System.Windows.Forms.Cursors.Default;
            this.Enter.Location = new System.Drawing.Point(319, 145);
            this.Enter.Name = "Enter";
            this.Enter.Size = new System.Drawing.Size(75, 23);
            this.Enter.TabIndex = 4;
            this.Enter.Text = "ورود";
            this.Enter.UseVisualStyleBackColor = true;
            this.Enter.Click += new System.EventHandler(this.Enter_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(137, 111);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(171, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(329, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "کلمه عبور";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(137, 76);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(171, 20);
            this.txtUserName.TabIndex = 1;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(329, 79);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(58, 13);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "نام کاربری";
            // 
            // requiredFieldValidator1
            // 
            this.requiredFieldValidator1.CancelFocusChangeWhenInvalid = false;
            this.requiredFieldValidator1.ControlToValidate = this.txtUserName;
            this.requiredFieldValidator1.ErrorMessage = "نام کاربری را وارد کنید";
            this.requiredFieldValidator1.Icon = ((System.Drawing.Icon)(resources.GetObject("requiredFieldValidator1.Icon")));
            // 
            // requiredFieldValidator2
            // 
            this.requiredFieldValidator2.CancelFocusChangeWhenInvalid = false;
            this.requiredFieldValidator2.ControlToValidate = this.txtPassword;
            this.requiredFieldValidator2.ErrorMessage = "رمز عبور را وارد کنید";
            this.requiredFieldValidator2.Icon = ((System.Drawing.Icon)(resources.GetObject("requiredFieldValidator2.Icon")));
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 270);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmLogin";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "frmLogin";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Enter;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblUserName;
        private ValidationComponents.RequiredFieldValidator requiredFieldValidator1;
        private ValidationComponents.RequiredFieldValidator requiredFieldValidator2;
    }
}