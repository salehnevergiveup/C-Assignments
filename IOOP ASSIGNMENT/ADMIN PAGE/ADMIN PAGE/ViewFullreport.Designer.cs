namespace ADMIN_PAGE
{
    partial class ViewFullreport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewFullreport));
            this.panel9 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.btnnormal = new System.Windows.Forms.Button();
            this.btnmini = new System.Windows.Forms.Button();
            this.btnmax = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataFullreport = new System.Windows.Forms.DataGridView();
            this.panel13 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnclosepage = new System.Windows.Forms.Button();
            this.sidebartime = new System.Windows.Forms.Timer(this.components);
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataFullreport)).BeginInit();
            this.panel13.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(134)))), ((int)(((byte)(138)))));
            this.panel9.Controls.Add(this.label2);
            this.panel9.Controls.Add(this.panel10);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(929, 59);
            this.panel9.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(251, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(330, 59);
            this.label2.TabIndex = 6;
            this.label2.Text = "View Report Details";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.btnnormal);
            this.panel10.Controls.Add(this.btnmini);
            this.panel10.Controls.Add(this.btnmax);
            this.panel10.Controls.Add(this.btnClose);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel10.Location = new System.Drawing.Point(581, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(348, 59);
            this.panel10.TabIndex = 2;
            // 
            // btnnormal
            // 
            this.btnnormal.BackColor = System.Drawing.Color.Transparent;
            this.btnnormal.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnnormal.BackgroundImage")));
            this.btnnormal.FlatAppearance.BorderSize = 0;
            this.btnnormal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnnormal.Location = new System.Drawing.Point(191, 14);
            this.btnnormal.Name = "btnnormal";
            this.btnnormal.Size = new System.Drawing.Size(35, 30);
            this.btnnormal.TabIndex = 5;
            this.btnnormal.UseVisualStyleBackColor = false;
            this.btnnormal.Click += new System.EventHandler(this.btnnormal_Click);
            // 
            // btnmini
            // 
            this.btnmini.BackColor = System.Drawing.Color.Transparent;
            this.btnmini.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnmini.BackgroundImage")));
            this.btnmini.FlatAppearance.BorderSize = 0;
            this.btnmini.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnmini.Location = new System.Drawing.Point(232, 12);
            this.btnmini.Name = "btnmini";
            this.btnmini.Size = new System.Drawing.Size(33, 38);
            this.btnmini.TabIndex = 4;
            this.btnmini.UseVisualStyleBackColor = false;
            this.btnmini.Click += new System.EventHandler(this.btnmini_Click);
            // 
            // btnmax
            // 
            this.btnmax.BackColor = System.Drawing.Color.Transparent;
            this.btnmax.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnmax.BackgroundImage")));
            this.btnmax.FlatAppearance.BorderSize = 0;
            this.btnmax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnmax.Location = new System.Drawing.Point(271, 12);
            this.btnmax.Name = "btnmax";
            this.btnmax.Size = new System.Drawing.Size(33, 30);
            this.btnmax.TabIndex = 3;
            this.btnmax.UseVisualStyleBackColor = false;
            this.btnmax.Click += new System.EventHandler(this.btnmax_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(310, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(34, 32);
            this.btnClose.TabIndex = 2;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(134)))), ((int)(((byte)(138)))));
            this.panel11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel11.Location = new System.Drawing.Point(0, 636);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(929, 43);
            this.panel11.TabIndex = 16;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightCyan;
            this.panel1.Controls.Add(this.dataFullreport);
            this.panel1.Controls.Add(this.panel13);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(929, 577);
            this.panel1.TabIndex = 18;
            // 
            // dataFullreport
            // 
            this.dataFullreport.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataFullreport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataFullreport.Location = new System.Drawing.Point(155, 237);
            this.dataFullreport.Name = "dataFullreport";
            this.dataFullreport.RowHeadersWidth = 51;
            this.dataFullreport.RowTemplate.Height = 29;
            this.dataFullreport.Size = new System.Drawing.Size(611, 337);
            this.dataFullreport.TabIndex = 18;
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.LightCyan;
            this.panel13.Controls.Add(this.label3);
            this.panel13.Controls.Add(this.label1);
            this.panel13.Controls.Add(this.button1);
            this.panel13.Controls.Add(this.comboBox2);
            this.panel13.Controls.Add(this.comboBox1);
            this.panel13.Controls.Add(this.btnclosepage);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel13.Location = new System.Drawing.Point(0, 0);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(929, 240);
            this.panel13.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(503, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 20);
            this.label3.TabIndex = 41;
            this.label3.Text = "Sort by";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(257, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 40;
            this.label1.Text = "Select month";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(134)))), ((int)(((byte)(138)))));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(694, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(223, 179);
            this.button1.TabIndex = 39;
            this.button1.Text = "View Full \r\nMonthly Report";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Level",
            "Subject"});
            this.comboBox2.Location = new System.Drawing.Point(503, 56);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(149, 28);
            this.comboBox2.TabIndex = 38;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.comboBox1.Location = new System.Drawing.Point(251, 56);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(236, 28);
            this.comboBox1.TabIndex = 37;
            // 
            // btnclosepage
            // 
            this.btnclosepage.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnclosepage.FlatAppearance.BorderSize = 0;
            this.btnclosepage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(134)))), ((int)(((byte)(138)))));
            this.btnclosepage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnclosepage.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnclosepage.Location = new System.Drawing.Point(21, 16);
            this.btnclosepage.Name = "btnclosepage";
            this.btnclosepage.Size = new System.Drawing.Size(147, 44);
            this.btnclosepage.TabIndex = 11;
            this.btnclosepage.Text = "Close";
            this.btnclosepage.UseVisualStyleBackColor = false;
            this.btnclosepage.Click += new System.EventHandler(this.btnclosepage_Click);
            // 
            // ViewFullreport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 679);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.panel9);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "ViewFullreport";
            this.Text = "ViewFullreport";
            this.Load += new System.EventHandler(this.ViewFullreport_Load);
            this.panel9.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataFullreport)).EndInit();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Panel panel9;
        private Label label2;
        private Panel panel10;
        private Button btnnormal;
        private Button btnmini;
        private Button btnmax;
        private Button btnClose;
        private Panel panel11;
        private Panel panel1;
        private DataGridView dataFullreport;
        private Panel panel13;
        private Button btnclosepage;
        private System.Windows.Forms.Timer sidebartime;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        private Button button1;
        private Label label3;
        private Label label1;
    }
}