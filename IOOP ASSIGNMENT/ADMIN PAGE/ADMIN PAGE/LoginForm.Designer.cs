namespace ADMIN_PAGE
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.labelwelcome = new System.Windows.Forms.Label();
            this.labeltuition = new System.Windows.Forms.Label();
            this.labelslogan = new System.Windows.Forms.Label();
            this.textBoxuserID = new System.Windows.Forms.TextBox();
            this.textBoxpassword = new System.Windows.Forms.TextBox();
            this.labeluserid = new System.Windows.Forms.Label();
            this.labelpassword = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnminimize = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelwelcome
            // 
            this.labelwelcome.AutoSize = true;
            this.labelwelcome.BackColor = System.Drawing.Color.Transparent;
            this.labelwelcome.Font = new System.Drawing.Font("Bernard MT Condensed", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelwelcome.ForeColor = System.Drawing.Color.Olive;
            this.labelwelcome.Image = ((System.Drawing.Image)(resources.GetObject("labelwelcome.Image")));
            this.labelwelcome.Location = new System.Drawing.Point(41, 33);
            this.labelwelcome.Name = "labelwelcome";
            this.labelwelcome.Size = new System.Drawing.Size(183, 39);
            this.labelwelcome.TabIndex = 0;
            this.labelwelcome.Text = "Welcome to ";
            this.labelwelcome.Click += new System.EventHandler(this.label1_Click);
            // 
            // labeltuition
            // 
            this.labeltuition.AutoSize = true;
            this.labeltuition.Cursor = System.Windows.Forms.Cursors.No;
            this.labeltuition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labeltuition.Font = new System.Drawing.Font("Bookman Old Style", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labeltuition.Location = new System.Drawing.Point(41, 73);
            this.labeltuition.Name = "labeltuition";
            this.labeltuition.Size = new System.Drawing.Size(808, 70);
            this.labeltuition.TabIndex = 1;
            this.labeltuition.Text = "Excellent Tuition Centre";
            this.labeltuition.Click += new System.EventHandler(this.label2_Click);
            // 
            // labelslogan
            // 
            this.labelslogan.AutoSize = true;
            this.labelslogan.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.labelslogan.Font = new System.Drawing.Font("Britannic Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelslogan.Location = new System.Drawing.Point(206, 150);
            this.labelslogan.Name = "labelslogan";
            this.labelslogan.Size = new System.Drawing.Size(454, 26);
            this.labelslogan.TabIndex = 2;
            this.labelslogan.Text = "Specialist Teaching Advice Revision Services";
            // 
            // textBoxuserID
            // 
            this.textBoxuserID.Location = new System.Drawing.Point(364, 238);
            this.textBoxuserID.Name = "textBoxuserID";
            this.textBoxuserID.Size = new System.Drawing.Size(268, 27);
            this.textBoxuserID.TabIndex = 3;
            // 
            // textBoxpassword
            // 
            this.textBoxpassword.Location = new System.Drawing.Point(364, 299);
            this.textBoxpassword.Name = "textBoxpassword";
            this.textBoxpassword.PasswordChar = '●';
            this.textBoxpassword.Size = new System.Drawing.Size(268, 27);
            this.textBoxpassword.TabIndex = 4;
            // 
            // labeluserid
            // 
            this.labeluserid.AutoSize = true;
            this.labeluserid.Location = new System.Drawing.Point(206, 238);
            this.labeluserid.Name = "labeluserid";
            this.labeluserid.Size = new System.Drawing.Size(87, 20);
            this.labeluserid.TabIndex = 5;
            this.labeluserid.Text = "USER ID :";
            // 
            // labelpassword
            // 
            this.labelpassword.AutoSize = true;
            this.labelpassword.Location = new System.Drawing.Point(206, 306);
            this.labelpassword.Name = "labelpassword";
            this.labelpassword.Size = new System.Drawing.Size(117, 20);
            this.labelpassword.TabIndex = 6;
            this.labelpassword.Text = "PASSWORD :";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Black;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumAquamarine;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnLogin.Location = new System.Drawing.Point(281, 353);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(281, 53);
            this.btnLogin.TabIndex = 7;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(53, 132);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(791, 15);
            this.panel1.TabIndex = 8;
            // 
            // btnminimize
            // 
            this.btnminimize.BackColor = System.Drawing.Color.Transparent;
            this.btnminimize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnminimize.BackgroundImage")));
            this.btnminimize.FlatAppearance.BorderSize = 0;
            this.btnminimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnminimize.Location = new System.Drawing.Point(768, 9);
            this.btnminimize.Name = "btnminimize";
            this.btnminimize.Size = new System.Drawing.Size(33, 38);
            this.btnminimize.TabIndex = 11;
            this.btnminimize.UseVisualStyleBackColor = false;
            this.btnminimize.Click += new System.EventHandler(this.btnminimize_Click);
            // 
            // btnclose
            // 
            this.btnclose.BackColor = System.Drawing.Color.Transparent;
            this.btnclose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnclose.BackgroundImage")));
            this.btnclose.FlatAppearance.BorderSize = 0;
            this.btnclose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnclose.Location = new System.Drawing.Point(818, 12);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(34, 32);
            this.btnclose.TabIndex = 9;
            this.btnclose.UseVisualStyleBackColor = false;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(869, 506);
            this.Controls.Add(this.btnminimize);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.labelpassword);
            this.Controls.Add(this.labeluserid);
            this.Controls.Add(this.textBoxpassword);
            this.Controls.Add(this.textBoxuserID);
            this.Controls.Add(this.labelslogan);
            this.Controls.Add(this.labeltuition);
            this.Controls.Add(this.labelwelcome);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelwelcome;
        private Label labeltuition;
        private Label labelslogan;
        private TextBox textBoxuserID;
        private TextBox textBoxpassword;
        private Label labeluserid;
        private Label labelpassword;
        private Button btnLogin;
        private Panel panel1;
        private Button btnminimize;
        private Button btnclose;
    }
}